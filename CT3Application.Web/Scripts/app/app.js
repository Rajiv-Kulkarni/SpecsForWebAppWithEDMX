'use strict';

var StaffingCenterApp = angular.module('StaffingCenterApp', ['ngAnimate', 'ui.bootstrap', 'ngStorage']);


//Create service for toastr
angular.module('StaffingCenterApp')
    .value('toastrs', toastr);