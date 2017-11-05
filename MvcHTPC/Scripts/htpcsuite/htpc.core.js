/////////


var htpc.core.voiceRecognizing = false;
var htpc.core.voiceObject;
var htpc.core.voiceWords;


htpc.core.voiceObject = new webkitSpeechRecognition();

htpc.core.onSuccess = function (e) {
    console.log("success: " + e);
}
htpc.core.voiceStart = function () {
    if (htpc.core.voiceRecognizing) {
        htpc.core.voiceRecognizing.stop();
        return;
    }
    htpc.core.voiceObject.continuous = false;
    htpc.core.voiceObject.interimResults = true;
    htpc.core.voiceObject.lang = "en-US";
    htpc.core.voiceWords = "";
    htpc.core.voiceObject.start();
}

htpc.core.voiceObject.onresult = function (event) {
    console.log(event.results[0][0].transcript);
    htpc.core.voiceWords = event.results[0][0].transcript;
}

htpc.core.voiceObject.onerror = function (event) {
    console.log("error: " + event.error);
    console.log("errmsg: " + event.message);
}

htpc.core.voiceObject.onstart = function () {
    htpc.core.voiceRecognizing = true;
}

htpc.core.voiceObject.onend = function () {
    toggleMicrophone();
    htpc.core.voiceRecognizing = false;
    console.log("ended");
    console.log("You said: " + htpc.core.voiceWords);
    htpcVoiceCommand(htpc.core.voiceWords);
    var t_document = document.getElementsByClassName("button-microphone");
    if (htpc.core.voiceRecognizing) {
        for (var i = 0; i < t_document.length; i++) {
            t_document[i].src = "mic.png";
        }
    }
    htpc.core.voiceWords = "";
}

toggleMicrophone = function () {
    var t_document = document.getElementsByClassName("button-microphone");
    if (htpc.core.voiceRecognizing == true) {
        for (var i = 0; i < t_document.length; i++) {
            t_document[i].src = "mic.png";
        }
        return;
    }
    for (var i = 0; i < t_document.length; i++) {
        t_document[i].src = "mic-on.png";
    }
}


htpcVoiceCommand = function (msg) {
    if (msg.length > 1) {
        var t_message = msg.split(" ");

        if (t_message[0].toLowerCase() == "open") // the first word
        {
            location.assign("http://" + t_message[1].toLowerCase());
            return;
        }

        if (msg.toLowerCase() == "penis") // entire message
        {
            alert("Too much penis");
            return;
        }
        location.assign("https://www.google.com/?gws_rd=ssl#q=" + encodeURIComponent(msg));
    }
}

test = function () {
    //htpcVoiceRecognition();
    if (htpc.core.voiceRecognizing) {
        toggleMicrophone();
        htpc.core.voiceObject.stop();
        return;
    }
    htpc.core.voiceStart();
    toggleMicrophone();
}
