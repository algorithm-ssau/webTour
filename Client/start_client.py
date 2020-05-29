from flask import Flask, render_template, jsonify
import requests
import json

app = Flask(__name__)

@app.route('/')
def home():
    uriMuseums = "https://localhost:44356/api/sight/category/museum"
    uriTheatres = "https://localhost:44356/api/sight/category/theatre"
    uriCathedrals = "https://localhost:44356/api/sight/category/church"
    uriTop = "https://localhost:44356/api/sight/top3"
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
    uriMuseums = "https://localhost:44356/api/sight/category/museum"
    uriTheatres = "https://localhost:44356/api/sight/category/theatre"
    uriCathedrals = "https://localhost:44356/api/sight/category/church"
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

    uriSight = "https://localhost:44356/api/sight/" + id
    try:
        responseSight = requests.get(uriSight, verify=False)
    except requests.ConnectionError:
       return "Connection Error"
    dataSight = json.loads(responseSight.text)

    sight = dataSight['data']

    return render_template("sight.html", sight=sight, museums=museums, theatres=theatres, cathedrals=cathedrals)

if __name__ == "__main__":
    app.run()