


//avoid collisions by encapsulation and all the code in the document knows about each other
$(document).ready(function () { //wrap the document inside a jQuery object and use the ready function.
          //^ ready is going to execute whatever is in block of code as soon as the browser is ready
    var theForm = $("#theForm"); //ezsample of using css selectors 
    theForm.hide();

    var button = $("#buyButton");
    button.on("click", function () {
        console.log("Buying Itme");
    });

    var productInfo = $(".product-props li");
    productInfo.on("click", function () {
        console.log("you clicked on" + $(this).text());
    });


    var $loginToggle = $("#loginToggle");
    var $popupForm = $(".popup-form");

    $loginToggle.on("click", function () {
        $popupForm.toggle(1000);
    });

});
