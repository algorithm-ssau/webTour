from flask import Flask, render_template, jsonify
import requests
import json

app = Flask(__name__)

BACKEND_ADRESS = "https://localhost:44356"

@app.route('/')
def home():
    uriMuseums = BACKEND_ADRESS + "/api/sight/category/Музеи"
    uriTheatres = BACKEND_ADRESS + "/api/sight/category/Театры"
    uriCathedrals = BACKEND_ADRESS + "/api/sight/category/Соборы"
    uriTop = BACKEND_ADRESS + "/api/sight/top3"
    try:
        responseMuseums = requests.get(uriMuseums, verify=False)
        responseTheatres = requests.get(uriTheatres, verify=False)
        responseCathedrals = requests.get(uriCathedrals, verify=False)
        responseTop = requests.get(uriTop, verify=False)
    except requests.ConnectionError:
       return "Connection Error"
    dataMuseums = json.loads(responseMuseums.text)
    dataTheatres = json.loads(responseTheatres.text)
    dataCathedrals = json.loads(responseCathedrals.text)
    dataTop = json.loads(responseTop.text)

    museums = []
    theatres = []
    cathedrals = []
    toplist = []

    for museum in dataMuseums['data']:
        museums.append(museum)
    
    for theatre in dataTheatres['data']:
        theatres.append(theatre)

    for cathedral in dataCathedrals['data']:
        cathedrals.append(cathedral)

    for top in dataTop['data']:
        toplist.append(top)

    return render_template("main.html", museums=museums, theatres=theatres, cathedrals=cathedrals, toplist=toplist)

@app.route('/sight/<id>')
def sight(id):
    uriMuseums = BACKEND_ADRESS + "/api/sight/category/Музеи"
    uriTheatres = BACKEND_ADRESS + "/api/sight/category/Театры"
    uriCathedrals = BACKEND_ADRESS + "/api/sight/category/Соборы"
    try:
        responseMuseums = requests.get(uriMuseums, verify=False)
        responseTheatres = requests.get(uriTheatres, verify=False)
        responseCathedrals = requests.get(uriCathedrals, verify=False)
    except requests.ConnectionError:
       return "Connection Error"
    dataMuseums = json.loads(responseMuseums.text)
    dataTheatres = json.loads(responseTheatres.text)
    dataCathedrals = json.loads(responseCathedrals.text)

    museums = []
    theatres = []
    cathedrals = []

    for museum in dataMuseums['data']:
        museums.append(museum)
    
    for theatre in dataTheatres['data']:
        theatres.append(theatre)

    for cathedral in dataCathedrals['data']:
        cathedrals.append(cathedral)

    uriSight = BACKEND_ADRESS + "/api/sight/" + id
    try:
        responseSight = requests.get(uriSight, verify=False)
    except requests.ConnectionError:
       return "Connection Error"
    dataSight = json.loads(responseSight.text)

    sight = dataSight['data']

    return render_template("sight.html", sight=sight, museums=museums, theatres=theatres, cathedrals=cathedrals)

@app.route('/category/<category_name>')
def category(category_name):
    uriMuseums = BACKEND_ADRESS + "/api/sight/category/Музеи"
    uriTheatres = BACKEND_ADRESS + "/api/sight/category/Театры"
    uriCathedrals = BACKEND_ADRESS + "/api/sight/category/Соборы"
    try:
        responseMuseums = requests.get(uriMuseums, verify=False)
        responseTheatres = requests.get(uriTheatres, verify=False)
        responseCathedrals = requests.get(uriCathedrals, verify=False)
    except requests.ConnectionError:
       return "Connection Error"
    dataMuseums = json.loads(responseMuseums.text)
    dataTheatres = json.loads(responseTheatres.text)
    dataCathedrals = json.loads(responseCathedrals.text)

    museums = []
    theatres = []
    cathedrals = []

    for museum in dataMuseums['data']:
        museums.append(museum)
    
    for theatre in dataTheatres['data']:
        theatres.append(theatre)

    for cathedral in dataCathedrals['data']:
        cathedrals.append(cathedral)

    target_category = []

    if category_name == "Музеи":
        target_category = museums

    if category_name == "Театры":
        target_category = theatres

    if category_name == "Соборы":
        target_category = cathedrals

    i = 0
    formatted_category = []
    while i < (len(target_category) / 2) + (len(target_category) % 2):
        try:
            formatted_category.append([target_category[i], target_category[i+1]])
        except:
            formatted_category.append([target_category[i]])
        i += 2

    return render_template("category.html", target_list=formatted_category, category=category_name, museums=museums, theatres=theatres, cathedrals=cathedrals)

if __name__ == "__main__":
    app.run()