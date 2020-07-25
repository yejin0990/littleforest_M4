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

![UI 사진](https://user-images.githubusercontent.com/56148289/88454743-9227cc80-ceac-11ea-95b4-9f5d539336ee.png)


**1. 시작, 로딩**

![1  시작, 로딩](https://user-images.githubusercontent.com/56148289/88453395-6bb06400-cea1-11ea-83bc-b296fddfa65e.png)

**2. 퀘스트**

![2  퀘스트](https://user-images.githubusercontent.com/56148289/88453406-87b40580-cea1-11ea-837d-77177d9b8a8f.png)

**3. 힐링지수**

![3  힐링지수](https://user-images.githubusercontent.com/56148289/88454663-1fb6ec80-ceac-11ea-8e4d-0d422d78777c.png)

**4. 사진 감정분석**

![4  사진 감정분석](https://user-images.githubusercontent.com/56148289/88454687-3bba8e00-ceac-11ea-9616-306d369253b5.png)

**5. 음성텍스트 감정분석**

![5  음성텍스트 감정분석](https://user-images.githubusercontent.com/56148289/88454707-4f65f480-ceac-11ea-9fa5-c67990272c09.png)

**6. 힐링 진단서**

![6  힐링 진단서](https://user-images.githubusercontent.com/56148289/88454716-5c82e380-ceac-11ea-85d1-7a2d24c2cae0.png)

**7. 소식지**

![7  소식지](https://user-images.githubusercontent.com/56148289/88454726-69073c00-ceac-11ea-8f62-812352316808.png)

**8. 아이템**

![8  아이템](https://user-images.githubusercontent.com/56148289/88454730-715f7700-ceac-11ea-900e-835ae8ef7766.png)

**9. 미니게임**

![9  미니게임](https://user-images.githubusercontent.com/56148289/88454736-7e7c6600-ceac-11ea-9d91-81a8f8d4aae9.png)

## Reference
## License
## 팀 소개
![형섭](https://user-images.githubusercontent.com/56148289/88451072-e459f500-ce8e-11ea-87cb-e58f4f0abadb.png)

**º 김형섭**


-팀장

-gudtjq4302@naver.com

-이미지, 음성, 문장 등의 감정 분석 모델링

![민정](https://user-images.githubusercontent.com/56148289/88451090-08b5d180-ce8f-11ea-85b2-87f5a24a8830.png)

**º 강민정**



-minj2058@gmail.com

-퀘스트나 스토리 진행, 대화 · 상점 시스템 및 UI 제작, 힐링지수 계산


![예진](https://user-images.githubusercontent.com/56148289/88451087-005d9680-ce8f-11ea-88e9-3448c67bcbae.png)

**º 손예진**



-Yj0990099@inu.ac.kr

-게임내 디자인 및 UI 제작, 미니게임 제작, 게임 내 효과음 적용

![서현](https://user-images.githubusercontent.com/56148289/88451093-0ce1ef00-ce8f-11ea-9503-13914d3a7a25.png)

**º 윤소현**



-ysh0714@naver.com

-안드로이드 환경 구축 및 개발, 사용자 데이터 저장 및 로드
