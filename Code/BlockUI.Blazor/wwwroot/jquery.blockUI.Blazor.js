window.blockUserInterfaceWrapper = {
    block: function (elementId, message) {
        var elem = document.getElementById(elementId);
        if (!elem) {
            throw new Error('No element with ID ' + elementId);
        }

        if (message)
            $(elem).block({ message: message });
        else
            $(elem).block();
    },
    blockWithDomElement: function (elementId, messageElementId) {
        var elem = document.getElementById(elementId);
        var msgElem = document.getElementById(messageElementId);
        if (!elem) {
            throw new Error('No element with ID ' + elementId);
        }
        if (!msgElem) {
            throw new Error('No element with ID ' + messageElementId);
        }

        $(elem).block({ message: $(msgElem) });
    },
    unblock: function (elementId) {
        var elem = document.getElementById(elementId);
        if (!elem) {
            throw new Error('No element with ID ' + elementId);
        }

        $(elem).unblock();
    },
    blockUI: function (message) {
        if (message)
            $.blockUI({ message: message });
        else 
            $.blockUI();
    },
    blockUIWithDomElement: function (messageElementId) {
        var msgElem = document.getElementById(messageElementId);
        if (!msgElem) {
            throw new Error('No element with ID ' + messageElementId);
        }

        $.blockUI({ message: $(msgElem) });
    },
    unblockUI: function () {
        $.unblockUI(); 
    }
};
