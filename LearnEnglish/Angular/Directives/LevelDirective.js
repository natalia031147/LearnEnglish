

angular.module('learnEnglishApp.directives', []).directive("level", function () {
    //define the directive object
    var directive = {};

    //restrict = E, signifies that directive is Element directive
    directive.restrict = "E";

    //template replaces the complete element with its text. 
    directive.template = "<div>{{level.level}}</b>";

    //scope is used to distinguish each student element based on criteria.
    directive.scope = {
        level: "=level"
    };

    //compile is called during application initialization. AngularJS calls it once when html page is loaded.

    directive.compile = function(element) {
        element.css("border", "1px solid rgb(204, 204, 204)");

        //linkFunction is linked with each element with scope to get the element specific data.
        var linkFunction = function($scope, element) {
            var strLevel;
            var backgroundColor;
            switch ($scope.level) {
            case 1:
                strLevel = "Elementary";
                backgroundColor = "#8db234";
                break;
            case 2:
                strLevel = "Pre-Intermediate";
                backgroundColor = "#ffba00";
                break;
            case 3:
                strLevel = "Intermediate";
                backgroundColor = "#e86d12";
                break;
            case 4:
                strLevel = "Under-Intermediate";
                backgroundColor = "#e13a19";
                break;
            case 5:
                strLevel = "Advanced";
                backgroundColor = "#d42b77";
                break;
            default:
                strLevel = "Undefined";
                backgroundColor = "#0cf";
            }
            element.html('<div style="border-radius: 15px; padding-left: 15px; width: 165px; background-color:' + backgroundColor + '">' + strLevel + "</div>");
            //element.css("background-color", backgroundColor);
            element.css("color", "whitesmoke");
            element.css("border", "none");
        };
        return linkFunction;
    };
    return directive;
});