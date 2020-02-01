/**
 * comments section:
 */
"use strict";
(function() {
  var element = document.getElementById("duck");
  console.log("Uncle Scrooge is ready");
  console.log(element);
  element.addEventListener("click", function() {
    element.innerHTML = "<p>Welcome</p>";
    console.log("duck clicked");
  });

  element.addEventListener("mouseover", function() {
    element.style.left = element.offsetLeft + 20 + "px";
    console.log("mouse over");
  });
})();
