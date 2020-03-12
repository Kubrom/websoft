/**
 * @author Kubrom
 */
"use strict";
const winningNum = new Array(7);
const guessednum = new Array(7);
guessednum[0] = document.getElementsByName('guess1').value;
console.log(guessednum);
const generateLotto = () => {
  for (let i = 0; i < winningNum.length; i++) {
    winningNum[i] = Math.floor(Math.random() * 36);
    console.log(winningNum[i]);
  }
};
