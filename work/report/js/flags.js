document.getElementById("italyLink").onclick = function() {
  makeFlagDisapear();

  createFlag("green", "white", "red");
};

document.getElementById("franceLink").onclick = function() {
  makeFlagDisapear();

  createFlag("blue", "white", "red");
};

document.getElementById("guineaLink").onclick = function() {
  makeFlagDisapear();
  createFlag("red", "yellow", "green");
};
document.getElementById("belgiumLink").onclick = function() {
  makeFlagDisapear();
  createFlag("black", "yellow", "red");
};
document.getElementById("nigeriaLink").onclick = function() {
  makeFlagDisapear();
  createFlag("green", "white", "green");
};

document.getElementById("image").onclick = function() {
  makeFlagDisapear();
};

function createFlag(color1, color2, color3) {
  document.getElementById("image").style.opacity = "1";
  document.getElementById("image").style.visibility = "visible";
  document.getElementById("color1").style.backgroundColor = color1;
  document.getElementById("color2").style.backgroundColor = color2;
  document.getElementById("color3").style.backgroundColor = color3;
}

function makeFlagDisapear() {
  document.getElementById("image").style.opacity = "0";
  document.getElementById("image").style.visibility = "hidden";
}
