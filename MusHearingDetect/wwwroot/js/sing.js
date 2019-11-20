URL = window.URL || window.webkitURL;
var gumStream; 						//stream from getUserMedia()
var rec; 							//Recorder.js object
var input; 							//MediaStreamAudioSourceNode we'll be recording

var AudioContext = window.AudioContext || window.webkitAudioContext;
var audioContext //audio context to help us record

var reDoButton = document.getElementById("reDoButton");
var recordButton = document.getElementById("recordButton");
var recordIcon = document.querySelector(".recordbutton i");
recordIcon.addEventListener("click", toggleIcon);
reDoButton.addEventListener("click", tryAgain);

var next = document.getElementById("next");
var link = document.getElementById("link");

next.style.visibility = "hidden";
link.style.visibility = "hidden";

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
		rec.record();

	}).catch(function (err) {
		recordButton.disabled = false;      //enable the record button if getUserMedia() fails
	});
}


function stopRecording() {
		
	rec.stop();
	gumStream.getAudioTracks()[0].stop();       //stop microphone access
	recordButton.style.visibility = "hidden";
	//create the wav blob and pass it on to createDownloadLink
	rec.exportWAV(createDownloadLink);

 //   console.log("rec");
 //   console.log(rec);
 //   console.log("exportWav")
	//console.log(rec.exportWAV(createDownloadLink));

	
  

	//rec.getBuffer(function (audioarray) {
	//    var fd = new FormData();
		

	//    var audioString = JSON.stringify(audioarray);
	//    fd.append("audio_data", audioString);
	//    var xhr = new XMLHttpRequest();
	//    xhr.open("POST", "/Test/Sing", true);
	//    xhr.send(fd);
	//});
	//    $.ajax({
	//        type: "POST",
	//        url: '/Test/Sing',
	//        data: JSON.stringify(audioarray),
	//        dataType: "json",
	//        contentType: "application/json; charset=utf-8",
	//        success: function () { alert("Mapping Successful") },
	//        failure: function () { alert("not working..."); }
	//    });

	//});




}

function createDownloadLink(blob) {

	

	var url = URL.createObjectURL(blob);
	var filename = "recording" + GetURLParameter();
	
	//save to disk link
	link.href = url;
	link.download = filename + ".wav"; //download forces the browser to donwload the file using the  filename

	document.getElementById("recsrc").value = link.download;
	link.style.visibility = "visible";

	
	//xhr.onload = function (e) {
	//	if (this.readyState === 4) {
	//		console.log("Server returned: ", e.target.responseText);
	//	}
	//};
	//var fd = new FormData();
	//fd.append("audio_data", blob, "recording");
	//var xhr = new XMLHttpRequest();
	//xhr.open("POST", "/Test/Sing", true);
	//var fileContent = window.btoa(blob);
	//console.log(fileContent);
	//xhr.send(JSON.stringify({ data: fileContent }));

 
   

	
	

}
function tryAgain() {
	rec.clear;
	recordButton.style.visibility = "visible";
	//recordIcon.classList.toggle("fa-microphone");

	link.style.visibility = "hidden";
	reDoButton.style.visibility = "hidden";
}

function GetURLParameter() {
	var sPageURL = window.location.href;
	var indexOfLastSlash = sPageURL.lastIndexOf("/");
	if (indexOfLastSlash > 0 && sPageURL.length - 1 != indexOfLastSlash)
		return sPageURL.substring(indexOfLastSlash + 1);
	else
		return 0;
}

