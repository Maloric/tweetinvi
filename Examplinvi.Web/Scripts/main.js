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
        var listItem = '<li class="list-group-item"><span class="handle">' + tweet.UserHandle + '</span> ' + tweet.Text + '</li>';
        $('#tweets').prepend(listItem);
    };

    tweetHub.client.log = function(log) {
        console.log(log);
    };

    $('#start').click(function () {
        
        $(this).prop('disabled', true).addClass('disabled');
        $('#stop').prop('disabled', false).removeClass('disabled');

        var streamType = $('input[name="stream-type"]').val();
        tweetHub.server.startStream(streamType);

        var isValid = false;

        if (streamType === 'user')
        {
            var userNameInput = $('#user-name');

            if (userNameInput.val().length > 0)
            {
                isValid = true;
            }
        }
        else if (streamType === 'filtered')
        {

        }
        else if (streamType === 'sample')
        {

        }
        console.log('Message from Client: Starting stream (Stream type: ' + streamType + ')');
    });

    $('#stop').click(function () {
        console.log('Message from Client: Stopping stream');
        $(this).prop('disabled', true).addClass('disabled');
        $('#start').prop('disabled', false).removeClass('disabled');
        var streamType = $('input[name="stream-type"]').val();
        tweetHub.server.stopStream(streamType);
    });

    $.connection.hub.start().done(function() {
        console.log('Message from Client: Connected to hub with client id: ' + $.connection.hub.id);
    });

    $.connection.hub.error(function (error) {
        console.log('SignalR error: ' + error)
    });
    // End SignalR stuff
});
$(document).on('change', '.btn-file :file', function () {
    var input = $(this),
        numFiles = input.get(0).files ? input.get(0).files.length : 1,
        label = input.val().replace(/\\/g, '/').replace(/.*\//, '');
    input.trigger('fileselect', [numFiles, label]);
});
