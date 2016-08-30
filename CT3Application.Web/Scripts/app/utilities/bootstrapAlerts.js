(function () {

	var alertService = {
		showAlert: showAlert,
		success: success,
		info: info,
		warning: warning,
		error: error
	};

	window.alerts = alertService;

	var alertContainer = $(".alert-container");

	var template = _.template("<div class='alert <%= alertClass %> alert-dismissable'>" +
		"<button type='button' class='close' data-dismiss='alert' aria-hidden='true'>&times;</button>" +
		"<%= message %>" +
		"</div>");

	function showAlert(alert) {
		var alertElement = $(template(alert));
		alertContainer.append(alertElement);
		if ((alert.duration === 'undefined') || alert.duration==null || alert.duration=="") {
		    alert.duration = '3000';
		}
		console.log(alert);
		console.log(alert.alertClass);
		console.log(alert.duration);
		window.setTimeout(function () {
		    //console.log('setTimeout called.');
		    //console.log(alert.message);
			alertElement.fadeOut();
		}, alert.duration);
	}

	function success(message, duration) {
	    showAlert({ alertClass: "alert-success", message: message, duration: duration });
	}

	function info(message, duration) {
	    showAlert({ alertClass: "alert-info", message: message, duration: duration });
	}

	function warning(message, duration) {
	    showAlert({ alertClass: "alert-warning", message: message, duration: duration });
	}

	function error(message, duration) {
	    showAlert({ alertClass: "alert-danger", message: message, duration: duration });
	}

})();
