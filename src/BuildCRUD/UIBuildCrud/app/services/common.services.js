(function () {
	"use strict";
	angular
	 .module("app")
            .constant("appSettings",
			{
			    base: angular.element("base").attr("href"),
			    localPath:  location.protocol + '//' + location.host + '/' + angular.element("base").attr("href"),
			    serverPath: "http://localhost:55847/api/",
			    defaultPageAfterLogin: "/search"
			});
}());