//webkitURL is deprecated but nevertheless
URL = window.URL || window.webkitURL;

var gumStream; 						//stream from getUserMedia()
var rec; 							//Recorder.js object
var input; 							//MediaStreamAudioSourceNode we'll be recording

// shim for AudioContext when it's not avb. 
var AudioContext = window.AudioContext || window.webkitAudioContext;
var audioContext //audio context to help us record

var recordButton = document.getElementById("recordButton");
var stopButton = document.getElementById("stopButton");
var next = document.getElementById("next");
var link = document.getElementById("link");
next.style.visibility = "hidden";
link.style.visibility = "hidden";

recordButton.addEventListener("click", startRecording);
stopButton.addEventListener("click", stopRecording);


function startRecording() {
	
    recordButton.disabled = true;
    recordButton.style.color = "red";
	stopButton.disabled = false



	navigator.mediaDevices.getUserMedia({
		audio: {
			sampleRate: 44100,
			channelCount: 1
		}
	}).then(function (stream) {


		audioContext = new AudioContext();
		gumStream = stream;
		input = audioContext.createMediaStreamSource(stream);

		rec = new Recorder(input, { numChannels: 1 })
        
		rec.record();


	}).catch(function (err) {
		//enable the record button if getUserMedia() fails
		recordButton.disabled = false;
		stopButton.disabled = true
	});
}


function stopRecording() {

    recordButton.style.color = "#de8f92";
	stopButton.disabled = true;
	recordButton.disabled = true;
	
	rec.stop();

	//stop microphone access
	gumStream.getAudioTracks()[0].stop();

	//create the wav blob and pass it on to createDownloadLink
	rec.exportWAV(createDownloadLink);
    
}

function createDownloadLink(blob) {

	var url = URL.createObjectURL(blob);
	//var link = document.createElement('a');
	var filename = "recording" + GetURLParameter();
	

	//save to disk link
	link.href = url;
	link.download = filename + ".wav"; //download forces the browser to donwload the file using the  filename
    //link.innerHTML = "Akceptuj";

    document.getElementById("recsrc").value = link.download;
    link.style.visibility = "visible";
	//recordinglst.appendChild(link);
	
}

function GetURLParameter() {
	var sPageURL = window.location.href;
	var indexOfLastSlash = sPageURL.lastIndexOf("/");

	if (indexOfLastSlash > 0 && sPageURL.length - 1 != indexOfLastSlash)
		return sPageURL.substring(indexOfLastSlash + 1);
	else
		return 0;
}