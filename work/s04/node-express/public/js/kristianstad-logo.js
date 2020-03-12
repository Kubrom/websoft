function makeShapeAppear() {
  let top = Math.random() * 400;
  let left = Math.random() * 800;
  let width = Math.random() * 200 + 100;

  document.getElementById("shape").style.borderRadius = "50%";
  document.getElementById("shape").style.top = top + "px";
  document.getElementById("shape").style.left = left + "px";
  document.getElementById("shape").style.display = "block";
  start = new Date().getTime();
}

function appearAfterDelay() {
  setTimeout(makeShapeAppear, Math.random() * 3000);
}
appearAfterDelay();

document.getElementById("shape").onclick = function() {
  document.getElementById("shape").style.display = "none";
  appearAfterDelay();
};
