$(function() {
    // Moved this from the Layout.cshtml file:

    $('.btn-file :file').on('fileselect', function (event, numFiles, label) {

        var input = $(this).parents('.input-group').find(':text'),
            log = numFiles > 1 ? numFiles + ' files selected' : label;

        if (input.length) {
            input.val(log);
        } else {
            if (log) alert(log);
        }

    });

    // SignalR stuff

    var tweetHub = $.connection.tweetHub;

    tweetHub.client.broadcastTweet = function(tweet) {
        console.log(tweet);
    };

    tweetHub.client.log = function(log) {
        console.log(log);
    };

    $('#start').click(function () {
        console.log('Message from Client: Starting stream');
        $(this).prop('disabled', true).addClass('disabled');
        $('#stop').prop('disabled', false).removeClass('disabled');
        tweetHub.server.startStream('filtered');
    });

    $('#stop').click(function () {
        console.log('Message from Client: Stopping stream');
        tweetHub.server.stopStream('filtered');
    });

    $.connection.hub.start().done(function() {
        console.log('Message from Client: Connected to hub with client id: ' + $.connection.hub.id);
    });
    // End SignalR stuff
});
$(document).on('change', '.btn-file :file', function () {
    var input = $(this),
        numFiles = input.get(0).files ? input.get(0).files.length : 1,
        label = input.val().replace(/\\/g, '/').replace(/.*\//, '');
    input.trigger('fileselect', [numFiles, label]);
});
