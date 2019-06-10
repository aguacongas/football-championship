window.browserJsFunctions = {
    scrollElementIntoView: function (id, behavior, block, inline) {
        behavior = behavior || 'smooth';
        block = block || 'start';
        inline = inline || 'nearest';
        const element = document.querySelector('#' + id);
        if (element) {
            element.scrollIntoView({ behavior: behavior, block: block });
            return true;
        }
        return false
    },
    getLanguage: function () {
        return navigator.language || navigator.userLanguage;
    },
    getBrowserTimeZoneOffset: function() {
        return new Date().getTimezoneOffset();
    },
    getBrowserTimeZoneIdentifier: function () {
        return Intl.DateTimeFormat().resolvedOptions().timeZone;
    },
    storage: {
        setItem: function (key, value) {
            localStorage.setItem(key, value);
        },
        getItem: function (key) {
            return localStorage.getItem(key);
        }
    },
    location: {
        pathname: function() {
            return location.pathname;
        }
    }
};
