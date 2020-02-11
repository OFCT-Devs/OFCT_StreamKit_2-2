var wait = ms => new Promise((r, j) => setTimeout(r, ms));

function readTextFile(file) {
    var returnText = new String();
    var rawFile = new XMLHttpRequest();
    rawFile.open("GET", file, false);
    rawFile.onreadystatechange = function () {
        if (rawFile.readyState === 4) {
            if (rawFile.status === 200 || rawFile.status == 0) {
                var allText = rawFile.responseText;
                returnText = allText;
            }
        }
    };
    rawFile.send(null);
    return returnText;
}

function getArrays(data, x, y, manual, count) {
    var dataToReturn = new Array();
    var i = 0;

    if (manual) {
        for (i = 0; i < count; i++) {
            content = data.data[y + i][x];
            dataToReturn[i] = content;
        }
        return dataToReturn;
    } else {
        while (true) {
            content = data.data[y + i][x];
            if (content === "" || content === undefined) {
                break;
            }
            dataToReturn[i] = content;
            i++;
        }
    }
    return dataToReturn;
}

const BGlinksCSS = [[], [], [], [], [], []];

function setBGlinks(IDss) {
    for (let i = 0; i < IDss.length; i++) {
        for (let j = 0; j < IDss[i].length; j++) {
            BGlinksCSS[i][j] = "url(https://assets.ppy.sh/beatmaps/" + IDss[i][j] + "/covers/cover.jpg)"
        }
    }
}

const DiffBGCSS = [[], [], [], [], [], []];

function setDiffBGCSS(Diffss) {
    for (let i = 0; i < Diffss.length; i++) {
        for (let j = 0; j < Diffss[i].length; j++) {
            if (Diffss[i][j] === "h"){
                DiffBGCSS[i][j] = "url(./HardOverlay.png), "
            } else if (Diffss[i][j] === "e"){
                DiffBGCSS[i][j] = "url(./EasyOverlay.png), "
            }
        }
    }
}


function typeToNum(type) {
    if (type === "NM") {
        return 0;
    } else if (type === "HD") {
        return 1;
    } else if (type === "HR") {
        return 2;
    } else if (type === "DT") {
        return 3;
    } else if (type === "FM") {
        return 4;
    } else if (type === "TB") {
        return 5;
    }
}

function numToType(num) {
    if (num === 0) {
        return "NM";
    } else if (num === 1) {
        return "HD";
    } else if (num === 2) {
        return "HR";
    } else if (num === 3) {
        return "DT";
    } else if (num === 4) {
        return "FM";
    } else if (num === 5) {
        return "TB";
    }
}

function setMapTitle(type, titles) {
    for (let i = 0; i < titles.length; i++) {
        titleToWrite = titles[i];
        titleToWrite = titleToWrite.split(" - ", 2)[1];
        document.getElementById(type + (i + 1)).innerHTML = titleToWrite;
        textFit(document.getElementById(type + (i + 1)))
    }
}

function setMapBG(type, IDs) {
    for (let i = 0; i < IDs.length; i++) {
        //document.getElementById(type + (i + 1)).style.background = "center center " + DiffBGCSS[typeToNum(type)][i] + "linear-gradient(rgba(0, 0, 0, 0.5), rgba(0, 0, 0, 0.3))," + BGlinksCSS[typeToNum(type)][i] + " center center";
        document.getElementById(type + (i + 1)).style.background = "center center linear-gradient(rgba(0, 0, 0, 0.5), rgba(0, 0, 0, 0.3))," + BGlinksCSS[typeToNum(type)][i] + " center center";
        //console.log(BGlinksCSS[typeToNum(type)][i]);
    }
}

async function init() {
    csv = readTextFile("../mapPick.csv");
    mapTitleList = Papa.parse(csv);
    //console.log(mapTitleList);

    var NM_titles = getArrays(mapTitleList, 0, 1);
    var HD_titles = getArrays(mapTitleList, 2, 1);
    var HR_titles = getArrays(mapTitleList, 4, 1);
    var DT_titles = getArrays(mapTitleList, 2, 6);
    var FM_titles = getArrays(mapTitleList, 4, 6);
    var TB_titles = getArrays(mapTitleList, 0, 10);

    setMapTitle("NM", NM_titles);
    setMapTitle("HD", HD_titles);
    setMapTitle("HR", HR_titles);
    setMapTitle("DT", DT_titles);
    setMapTitle("FM", FM_titles);
    setMapTitle("TB", TB_titles);

    csv = readTextFile("../mapSetIDs.csv");
    IDs = Papa.parse(csv);
    //console.log(IDs);

    var NM_IDs = getArrays(IDs, 0, 1);
    var HD_IDs = getArrays(IDs, 0, 10);
    var HR_IDs = getArrays(IDs, 0, 15);
    var DT_IDs = getArrays(IDs, 0, 20);
    var FM_IDs = getArrays(IDs, 0, 26);
    var TB_IDs = getArrays(IDs, 0, 31);

    /*var NM_Diffs = getArrays(IDs, 1, 1);
    var HD_Diffs = getArrays(IDs, 9, 1);
    var HR_Diffs = getArrays(IDs, 15, 1);
    var DT_Diffs = getArrays(IDs, 21, 1);
    var FM_Diffs = getArrays(IDs, 27, 1);*/

    setBGlinks([NM_IDs, HD_IDs, HR_IDs, DT_IDs, FM_IDs, TB_IDs]);
    //setDiffBGCSS([NM_Diffs, HD_Diffs, HR_Diffs, DT_Diffs, FM_Diffs]);
    DiffBGCSS[5][0] = "";
    //console.log(BGlinksCSS);

    setMapBG("NM", NM_IDs);
    setMapBG("HD", HD_IDs);
    setMapBG("HR", HR_IDs);
    setMapBG("DT", DT_IDs);
    setMapBG("FM", FM_IDs);
    setMapBG("TB", TB_IDs);

    setInterval(update, 1000);
    //update();
}

async function highlight(type, index, color) {
    for (let i = 0; i < BGlinksCSS.length; i++) {
        for (let j = 0; j < BGlinksCSS[i].length; j++) {
            //console.log(BGlinksCSS[i].length);
            //console.log(numToType(i) + (j + 1));
            document.getElementById(numToType(i) + (j + 1)).style.animation = "";
        }
    }
    if (color === "r") {
        document.getElementById(type + (index + 1)).style.animation = "pulse-red 0.7s infinite";
    } else if (color === "b") {
        document.getElementById(type + (index + 1)).style.animation = "pulse-blue 0.7s infinite";
    }
}

async function setMapBorder(type, index, status) {
    origBorder = document.getElementById(type + (index + 1)).style.border;
    if (status === "r") {
        document.getElementById(type + (index + 1)).style.border = "7px solid #D32F2F";
    } else if (status === "b") {
        document.getElementById(type + (index + 1)).style.border = "7px solid #0288D1";
    } else if (status === "reset") {
        document.getElementById(type + (index + 1)).style.border = "3px solid #FFFFFF";
    }

    if (origBorder !== document.getElementById(type + (index + 1)).style.border) {
        //console.log("change!!!");
        highlight(type, index, status);
    }
}

async function setBGcolor(type, index, color) {
    if (color === "r") {
        console.log("bg change");
        //document.getElementById(type + (index + 1)).style.background = "center center " + DiffBGCSS[typeToNum(type)][index] + "linear-gradient(rgba(0, 0, 0, 0.3), rgba(0, 0, 0, 0.3)), linear-gradient(rgba(229, 58, 64, 0.5), rgba(229, 58, 64, 0.5)), " + BGlinksCSS[typeToNum(type)][index] + "center center";
        document.getElementById(type + (index + 1)).style.background = "center center linear-gradient(rgba(0, 0, 0, 0.3), rgba(0, 0, 0, 0.3)), linear-gradient(rgba(229, 58, 64, 0.5), rgba(229, 58, 64, 0.5)), " + BGlinksCSS[typeToNum(type)][index] + "center center";
        document.getElementById(type + (index + 1)).style.color = "#ffcdd2";
    } else if (color === "b") {
        //document.getElementById(type + (index + 1)).style.background = "center center " + DiffBGCSS[typeToNum(type)][index] + "linear-gradient(rgba(0, 0, 0, 0.3), rgba(0, 0, 0, 0.3)), linear-gradient(rgba(48, 169, 222, 0.5), rgba(48, 169, 222, 0.5)), " + BGlinksCSS[typeToNum(type)][index] + "center center";
        document.getElementById(type + (index + 1)).style.background = "center center linear-gradient(rgba(0, 0, 0, 0.3), rgba(0, 0, 0, 0.3)), linear-gradient(rgba(48, 169, 222, 0.5), rgba(48, 169, 222, 0.5)), " + BGlinksCSS[typeToNum(type)][index] + "center center";
        document.getElementById(type + (index + 1)).style.color = "#bbdefb";
    } else if (color === "reset") {
        document.getElementById(type + (index + 1)).style.opacity = "1";
        //document.getElementById(type + (index + 1)).style.background = "center center " + DiffBGCSS[typeToNum(type)][index] + "linear-gradient(rgba(0, 0, 0, 0.5), rgba(0, 0, 0, 0.3)), " + BGlinksCSS[typeToNum(type)][index] + "center center";
        document.getElementById(type + (index + 1)).style.background = "center center linear-gradient(rgba(0, 0, 0, 0.5), rgba(0, 0, 0, 0.3)), " + BGlinksCSS[typeToNum(type)][index] + "center center";
        document.getElementById(type + (index + 1)).style.color = "#FFFFFF";
    }
}

async function setMapStatus(type, data) {
    for (let i = 0; i < data.length; i++) {
        if (data[i] !== "ban") {
            if (data[i] === "r") {
                setMapBorder(type, i, "r");
            } else if (data[i] === "b") {
                setMapBorder(type, i, "b");
            } else if (data[i] === "rr") {
                setMapBorder(type, i, "r");
                setBGcolor(type, i, "r");
                document.getElementById(type + (i + 1)).style.animation = "";
            } else if (data[i] === "rb") {
                setMapBorder(type, i, "r");
                setBGcolor(type, i, "b");
                document.getElementById(type + (i + 1)).style.animation = "";
            } else if (data[i] === "br") {
                setMapBorder(type, i, "b");
                setBGcolor(type, i, "r");
                document.getElementById(type + (i + 1)).style.animation = "";
            } else if (data[i] === "bb") {
                setMapBorder(type, i, "b");
                setBGcolor(type, i, "b");
                document.getElementById(type + (i + 1)).style.animation = "";
            } else {
                setMapBorder(type, i, "reset");
                setBGcolor(type, i, "reset");
            }
        } else if (data[i] === "ban") {
            document.getElementById(type + (i + 1)).style.opacity = "0.3";
        }
        textFit(document.getElementById(type + (i + 1)));
    }
}

async function update() {
    csv = readTextFile("../mapPick.csv");
    pickStatus = Papa.parse(csv);

    var NM_stat = getArrays(pickStatus, 1, 1, true, 7);
    var HD_stat = getArrays(pickStatus, 3, 1, true, 3);
    var HR_stat = getArrays(pickStatus, 5, 1, true, 3);
    var DT_stat = getArrays(pickStatus, 3, 6, true, 4);
    var FM_stat = getArrays(pickStatus, 5, 6, true, 3);
    var TB_stat = getArrays(pickStatus, 1, 10, true, 1);

    //console.log([NM_stat, HD_stat, HR_stat, DT_stat, FM_stat, TB_stat]);

    setMapStatus("NM", NM_stat);
    setMapStatus("HD", HD_stat);
    setMapStatus("HR", HR_stat);
    setMapStatus("DT", DT_stat);
    setMapStatus("FM", FM_stat);
    setMapStatus("TB", TB_stat);

    /*if (readTextFile("./redTitle.txt") === "Red") {
        document.getElementById("bottomDivRed").style.display = "flex";
        document.getElementById("bottomDivBlue").style.display = "none";
        if (readTextFile("./timerTitle.txt") === "픽") {
            document.getElementById("pickStatusRed").innerHTML = "Pick"
        } else if (readTextFile("./timerTitle.txt") === "밴") {
            document.getElementById("pickStatusRed").innerHTML = "Ban"
        }
        document.getElementById("timeLeftRed").innerHTML = readTextFile("./time.txt");
    } else if (readTextFile("./blueTitle.txt") === "Blue") {
        document.getElementById("bottomDivRed").style.display = "none";
        document.getElementById("bottomDivBlue").style.display = "flex";
        if (readTextFile("./timerTitle.txt") === "픽") {
            document.getElementById("pickStatusBlue").innerHTML = "Pick"
        } else if (readTextFile("./timerTitle.txt") === "밴") {
            document.getElementById("pickStatusBlue").innerHTML = "Ban"
        }
        document.getElementById("timeLeftBlue").innerHTML = readTextFile("./time.txt");
    } else {
        document.getElementById("bottomDivRed").style.display = "none";
        document.getElementById("bottomDivBlue").style.display = "none";
    }*/
}

init();