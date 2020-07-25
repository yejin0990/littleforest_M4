# littleforest

## 프로젝트 소개
본 프로젝트는 유니티를 통한 간단한 게임과 함께 사용자의 표정, 목소리, 텍스트를 통한 감정분석 결과와 행복지수 결과에 따라 힐링지수를 제공해주는 어플을 개발하는 것을 목표로 한다

사용 환경
window10 x64기반, python 3.6, Unity2019, GoogleCloud

## 실행 방법
python3.6(64bit) 버전에서 pip을 사용하여 flask 프로젝트를 수행할 가상환경을 세팅해놓아야 한다.
```python
mkdir flaskserver
cd flaskserver
conda create -n flaskserver python=3.6
```
가상환경 접속
```python
conda activate flaskserver
```
라이브러리 설치
```python
pip install -r requirements.txt
```
flask server실행
```python
python3 flaskserver.py
```

## 얼굴 인식 감정 분석 모델
https://www.kaggle.com/c/challenges-in-representation-learning-facial-expression-recognition-challenge/data
데이터를 사용
## 음성 인식 감정 분석 모델
https://github.com/MITESHPUTHRANNEU/Speech-Emotion-Analyzer 에서 Emtion_Voice_Detection_Model.h5, model.json 을 다운받아 실행파일 디렉토리에 둔다.
## Unity Setting
unity 폴더에 있는 폴더들을 다운받아 unity에 새 project를 생성하고 해당 파일들을 붙여넣고 실행을 시킨다.
scene에 있는 start를 더블클릭 해서 실행한다.

## 실행 화면





## Reference
## License
## 팀 소개
