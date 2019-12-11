URL = window.URL || window.webkitURL;
var gumStream; 						//stream from getUserMedia()
var rec; 							//Recorder.js object
var input; 							//MediaStreamAudioSourceNode we'll be recording
var AudioContext = window.AudioContext || window.webkitAudioContext;
var audioContext;


var reDoButton = document.getElementById("reDoButton");
var recordButton = document.getElementById("recordButton");
var recordIcon = document.getElementById("microphoneIcon");
var next = document.getElementById("nextbtn");

recordIcon.addEventListener('click', toggleIcon);
reDoButton.addEventListener("click", tryAgain);
next.addEventListener("click", goToNextQuest);

next.style.visibility = "hidden";

recordButton.addEventListener("click", checkClass);


function toggleIcon() {
	recordIcon.classList.toggle("fa-stop");
}

function checkClass() {
	if (recordIcon.classList.contains("fa-stop")) {

		console.log("start");
		startRecording();
	}
	else {
		console.log("stop");
		stopRecording();
		reDoButton.style.visibility = "visible";
		next.style.visibility = "visible";
		
		
	}
}

function startRecording() {
	navigator.mediaDevices.getUserMedia({
		audio: {
			sampleRate: 44100,
			channelCount: 1
		}
	}).then(function (stream) {
	
		audioContext = new AudioContext();
		gumStream = stream;
		input = audioContext.createMediaStreamSource(stream);
		rec = new Recorder(input, { numChannels: 1 });
		rec && rec.record();

	}).catch(function (err) {
		recordButton.disabled = false;   
	});
}


function stopRecording() {
		
	rec && rec.stop();
	gumStream.getAudioTracks()[0].stop();
	recordButton.style.visibility = "hidden";	
}

function goToNextQuest() {
	upload();
 
}

function reqListener(e) {
    if (GetURLParameter() == 19) {
        window.location.href = "/Test/Question/20";
    }
    else {
        window.location.href = "/Test/YourResult";
    }
}

function upload() {
    rec && rec.exportWAV(function (blob) {
        var fd = new FormData();
        var UrlParameter = GetURLParameter();
        fd.append("audio_data", blob);
        fd.append("param", UrlParameter);
        var xhr = new XMLHttpRequest();
        xhr.addEventListener("load", reqListener);
        xhr.open("POST", "/Test/Sing", true);
        xhr.send(fd);
	});
}


function tryAgain() {
	rec.clear;
	recordButton.style.visibility = "visible";  
	reDoButton.style.visibility = "hidden";
	next.style.visibility = "hidden";
}

function GetURLParameter() {
	var sPageURL = window.location.href;
	var indexOfLastSlash = sPageURL.lastIndexOf("/");
	if (indexOfLastSlash > 0 && sPageURL.length - 1 != indexOfLastSlash)
		return sPageURL.substring(indexOfLastSlash + 1);
	else
		return 0;
}

