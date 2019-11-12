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

//add events to those 2 buttons
recordButton.addEventListener("click", startRecording);
stopButton.addEventListener("click", stopRecording);

function startRecording() {
	console.log("recordButton clicked");

	/*
		Simple constraints object, for more advanced audio features see
		https://addpipe.com/blog/audio-constraints-getusermedia/
	*/

	recordButton.disabled = true;
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

		//start the recording
        rec.record();


	}).catch(function (err) {
		//enable the record button if getUserMedia() fails
		recordButton.disabled = false;
		stopButton.disabled = true
	});
}


function stopRecording() {
	console.log("stopButton clicked");

	//disable the stop button, enable the record too allow for new recordings
	stopButton.disabled = true;
	recordButton.disabled = true;
	
	//stop the recording
	rec.stop();

	//stop microphone access
	gumStream.getAudioTracks()[0].stop();

	//create the wav blob and pass it on to createDownloadLink
	rec.exportWAV(createDownloadLink);
}

function createDownloadLink(blob) {

	var url = URL.createObjectURL(blob);
	var li = document.createElement('p');
	var link = document.createElement('a');
	var filename = "recording";
	

	//save to disk link
	link.href = url;
	link.download = filename + ".wav"; //download forces the browser to donwload the file using the  filename
	link.innerHTML = "Akceptuj";
	link.addEventListener("click", makevisible);

	document.getElementById("recsrc").value = link.download;

	

	//add the save to disk link to li
	li.appendChild(link);

	
	recordinglst.appendChild(link);
	
}
function makevisible() {
	var nextbtn = document.getElementById('nextbtn');
	nextbtn.style.visibility = "visible";
} 