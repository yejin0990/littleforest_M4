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
![형섭](https://user-images.githubusercontent.com/56148289/88451072-e459f500-ce8e-11ea-87cb-e58f4f0abadb.png)

# º김형섭

-팀장
-201400273
-gudtjq4302@naver.com
-이미지, 음성, 문장 등의 감정 분석 모델링

![민정](https://user-images.githubusercontent.com/56148289/88451090-08b5d180-ce8f-11ea-85b2-87f5a24a8830.png)

# º강민정

-201700255
-minj00255@inu.ac.kr
-퀘스트나 스토리 진행, 대화 · 상점 시스템 및 UI 제작, 힐링지수 계산


![예진](https://user-images.githubusercontent.com/56148289/88451087-005d9680-ce8f-11ea-88e9-3448c67bcbae.png)

# º손예진

-201700272
-Yj0990099@inu.ac.kr
-게임내 디자인 및 UI 제작, 미니게임 제작, 게임 내 효과음 적용

![서현](https://user-images.githubusercontent.com/56148289/88451093-0ce1ef00-ce8f-11ea-9503-13914d3a7a25.png)

# º윤소현

-201700275
-ysh0714@naver.com
-안드로이드 환경 구축 및 개발, 사용자 데이터 저장 및 로드
