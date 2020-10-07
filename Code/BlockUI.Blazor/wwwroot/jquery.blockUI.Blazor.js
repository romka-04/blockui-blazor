window.blockUserInterfaceWrapper = {
    block: function (elementId) {
        console.log("block");
        var elem = document.getElementById(elementId);
        if (!elem) {
            throw new Error('No element with ID ' + elementId);
        }
        $(elem).block();
    },
    unblock: function (elementId) {
        console.log("unblock");
        var elem = document.getElementById(elementId);
        if (!elem) {
            throw new Error('No element with ID ' + elementId);
        }
        $(elem).unblock();
    }
};
