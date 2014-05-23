(function ($) {

    $(document).bind("mobileinit", function () {
        // As of Beta 2, jQuery Mobile's Ajax navigation does not work in all cases (e.g.,
        // when navigating from a mobile to a non-mobile page, or when clicking "back"
        // after a form post), hence disabling it.
        $.mobile.ajaxEnabled = false;
    });

    function showMessage(message) {
        var status = $('#status').text(message);

        if (status.css('display') === 'none') {
            status.slideDown('slow');
        }
    }

    function hideMessage() {
        setTimeout(function () {
            $('#status').slideUp('slow');
        }, 5 * 1000);
    }

    var offlineCache = window.applicationCache;

    if (!offlineCache) {
        showMessage('offline cache is not supported.');
        hideMessage();
        return;
    }

    $(offlineCache).bind('checking', function () {
        showMessage('checking cache...');
    });

    $(offlineCache).bind('noupdate', function () {
        showMessage('cache is up to date.');
        hideMessage();
    });

    $(offlineCache).bind('downloading', function () {
        showMessage('started downloading...');
    });

    $(offlineCache).bind('progress', function (e) {
        var msg = 'downloading assets...';
        if (e.originalEvent.total) {
            msg = 'downloading ' + e.originalEvent.loaded + ' of ' + e.originalEvent.total + '...';
        }
        showMessage(msg);
    });

    $(offlineCache).bind('updateready', function () {
        showMessage('downloaded new assets.');
        if (confirm('New updates are available, would you like to to reload?')) {
            window.location.reload();
        }
    });

    $(offlineCache).bind('cached', function () {
        showMessage('assets are now cached.');
        hideMessage();
    });

    $(offlineCache).bind('obsolete', function () {
        showMessage('cache has become obsolete.');
        hideMessage();
    });

    $(offlineCache).bind('error', function () {
        showMessage('oops, error occurred.');
        hideMessage();
    });
})(jQuery);