"use strict";
const winningNum = new Array(7);
const generateLotto = () => {
  for (let i = 0; i < winningNum.length; i++) {
    winningNum[i] = Math.floor(Math.random() * 36);
    console.log(winningNum[i]);
  }
};

generateLotto();
console.log(winningNum);
