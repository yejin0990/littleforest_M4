import flask
from flask import Flask, request, redirect, url_for, render_template, jsonify, json, make_response
import tensorflow as tf
from keras.preprocessing.image import img_to_array
from keras.applications import imagenet_utils
from PIL import Image
import numpy as np
import io
from keras.models import load_model
from werkzeug.utils import secure_filename
from keras.utils import np_utils
from sklearn.preprocessing import LabelEncoder
from keras.models import model_from_json
import os
import face_recognition
import cv2
import sys
import glob
import time
import sys
import pyrebase
import socketio
import librosa
import pandas as pd
from vaderSentiment.vaderSentiment import SentimentIntensityAnalyzer
from googletrans import Translator
import requests
import json
from pyowm import OWM


UPLOAD_FOLDER = '/home/tjgus7140/m4/static'
ALLOWED_EXTENSIONS = set(['png', 'jpg', 'jpeg', 'txt', 'wav', 'mp4'])
graph = tf.compat.v1.get_default_graph()

def extract_feature(file_name):
    X, sample_rate = librosa.load(file_name, res_type='kaiser_fast', duration=3, offset=0.5)
    sample_rate = np.array(sample_rate)
    mfccs = np.mean(librosa.feature.mfcc(y=X, n_mfcc=25),axis=0)
    mfccs = -(mfccs / 100)
    print("mfccs :", mfccs,"\n",mfccs.shape)
    return mfccs
# extract_feature('./angry/angry.wav')

app = Flask(__name__)

app.config['UPLOAD_FOLDER'] = UPLOAD_FOLDER

@app.route('/', methods=['POST','GET'])
def single_file():
    data = ""
    req = request.files
    print(req)
    receivefile = str(req)
    if 'jpg' in receivefile or 'png' in receivefile:
        print(request.files)
        data = ""
        EMOTIONS = ["angry" ,"Fear", "happy", "sad", "surprised"]
        model = load_model("/home/tjgus7140/model/Trained_Model.h5")
        image = request.files["image"]
        print(f"Filename: {image.filename}")
        print(f"Name: {image.name}")
        #print(image)

        imagepath = '/home/tjgus7140/m4/Images/' + image.filename
        image.save(imagepath)
        imageFace = cv2.imread(imagepath)

        faces = face_recognition.face_locations(imageFace)
        print("Found {0} faces!".format(len(faces)))
        for (x, y, w, h) in faces:
            cv2.rectangle(imageFace, (x, y), (x+w, y+h), (0, 255, 0), 2)
        for face in faces:
            #Print the location of each face in this image
            top, right, bottom, left = face
            #print("A face is located at pixel location Top: {}, Left: {}, Bottom: {}, Right: {}".format(top, left, bottom, right))
            # You can access the actual face itself like this:
            face_image = imageFace[top:bottom, left:right]
            #img = Image.fromarray(face_image)
            img = cv2.resize(face_image,(48,48))
            img = np.reshape(img,[1,48,48,3])
            ar=model.predict(img)
            ar = ar[0]
            for i in range(len(ar)):
                ar[i] = round(ar[i], 3)
            iar = ar.tolist()
            maxidx = iar.index(max(iar))
            print(ar)
            data += EMOTIONS[maxidx] + " "
            if max(ar) <= 0.6:
                data = "please send other image"
        # To save the image, call image.save() and provide a destination to save to
        # image.save("/path/to/uploads/directory/filename")
        print(data)
        with graph.as_default():
            response = {
                'face': {
                    "angry": float(ar[0]),
                    "Fear": float(ar[1]),
                    "happy": float(ar[2]),
                    "sad": float(ar[3]),
                    "surprised": float(ar[4])
            }
        }

    elif 'text' in receivefile and 'stream' in receivefile:
        print("letter")
        string = request.files
        print(string)
        string = request.files['text']
        print(string.filename)
        string.save("/home/tjgus7140/m4/Images/"+str(string.filename))
        stringpath = "/home/tjgus7140/m4/Images/"+str(string.filename)
        with open(stringpath,'r') as f:
            print(f.encoding)
            file_content = f.read()
        print(file_content)
        translator = Translator()
        analyzer = SentimentIntensityAnalyzer()

        file_content = translator.translate(file_content, dest="en")
        vs = analyzer.polarity_scores(file_content.text)
        prediction = vs
        response = str(prediction['compound'])
        print(response)

        data = response

    elif 'dat' in receivefile and 'image' in receivefile:
        print("voice")
        voice = request.files
        print(voice)
        voice = request.files['image']
        print(voice.filename)
        voice.save("/home/tjgus7140/m4/Images/"+str(voice.filename))
        voicepath = "/home/tjgus7140/m4/Images/"+str(voice.filename)

        lb = LabelEncoder()
        label = [
        "female_angry",
        "female_calm",
        "female_fearful",
        "female_happy",
        "female_sad",
        "male_angry",
        "male_calm",
        "male_fearful",
        "male_happy",
        "male_sad"
        ]

        json_file = open('/home/tjgus7140/m4/model/src/Speech-Emotion-Model/Speech_Emotion_Model_test/savedModel/model.json', 'r')
        loaded_model_json = json_file.read()
        json_file.close()
        loaded_model = model_from_json(loaded_model_json)
        # load weights into new model
        loaded_model.load_weights("/home/tjgus7140/m4/model/src/Speech-Emotion-Model/Speech_Emotion_Model_test/savedModel/Emotion_Voice_Detection_Model.h5")
        print("Loaded model from disk")

        X, sample_rate = librosa.load(voicepath, res_type='kaiser_fast', duration=2.5, sr=22050*2, offset=0.5)
        sample_rate = np.array(sample_rate)
        mfccs = np.mean(librosa.feature.mfcc(y=X, sr=sample_rate, n_mfcc=13), axis=0)

        featurelive =mfccs
        livedf2 = featurelive
        livedf2 = pd.DataFrame(data=livedf2)
        livedf2 = livedf2.stack().to_frame().T
        twodim = np.expand_dims(livedf2, axis=2)
        livepreds = loaded_model.predict(twodim, batch_size=32, verbose = 1)
        livepreds1 = livepreds.argmax(axis=1)
        liveabc = livepreds1.astype(int).flatten()
        #print(label[int(liveabc)])
        # 0 - female_angry
        # 1 - female_calm
        # 2 - female_fearful
        # 3 - female_happy
        # 4 - female_sad
        # 5 - male_angry
        # 6 - male_calm
        # 7 - male_fearful
        # 8 - male_happy
        # 9 - male_sad
        response = label[int(liveabc)]
        print(response)
        data = str(response)

    elif  'weather' in receivefile:
        print("weather")
        string = request.files
        print(string)
        string = request.files['weather']
        print(string.filename)
        string.save("/home/tjgus7140/m4/Images/"+str(string.filename))
        stringpath = "/home/tjgus7140/m4/Images/"+str(string.filename)
        with open(stringpath,'r') as f:
            print(f.encoding)
            file_content = f.read()
        my_ip = str(file_content)
        print(my_ip)
        geo_request = requests.get('https://get.geojs.io/v1/ip/geo/' +my_ip + '.json')
        geo_data = geo_request.json()
        #print({'latitude': geo_data['latitude'], 'longitude': geo_data['longitude']})


        api_key = "44ba4a8d4a7b16a0a0f8db330046ad67"
        lat = str(geo_data['latitude'])
        lon = str(geo_data['longitude'])
        url = "https://api.openweathermap.org/data/2.5/onecall?lat=%s&lon=%s&appid=%s&units=metric" % (lat, lon, api_key)

        response = requests.get(url)
        data = json.loads(response.text)
        current = data['current']
        cTemp = current['temp']
        print(cTemp)
        cWeather = current['weather']
        cWeather = cWeather[0]
        cWeather = cWeather['main']
        print(cWeather)

        print("현재 온도는 :{} \n현재 날씨는 : {} 입니다.".format(cTemp,cWeather))
        response = str(cTemp) + "," + str(cWeather)
        data = response

    return render_template('indextest.html', data=data)

if __name__ == "__main__":
    app.run(host = "0.0.0.0", port = 443, debug = False, threaded = False)

# ps -fA | grep python
# kill -9 pid
# pkill -9 python
