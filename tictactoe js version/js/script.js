var tiles = document.getElementsByClassName("tile");
var buttons = document.getElementsByClassName("button");
var title = document.getElementById("title");
console.log(title);

var state = [0,0,0,0,0,0,0,0,0];
var game = true;

var HUMAN = false;
var COMPUTER = true;

var HUMVAL = -1;
var COMVAL  = 1;

var winMatrix =[
                [0,1,2],
                [3,4,5],
                [6,7,8],
                [0,3,6],
                [1,4,7],
                [2,5,8],
                [0,4,8],
                [2,4,6]
              ];

function reset(){
  for (var i = 0; i < 9; i++) {
        tiles[i].style.background = "#fff";
        state[i] = 0;
  }
  for (var i = 0; i < 2; i++) {
    buttons[i].style.width = "15.5vh";
    buttons[i].style.margin = "0.5vh";
    buttons[i].style.opacity = "1";
  }
  title.innerHTML = "Try To Win :)"
  game = true;
}

function move(clicked){
  if(!game)
    return;

    for (var i = 0; i < 9; i++) {
      if(tiles[i]==clicked&&state[i]==0){
        set(i,HUMAN);
        callAI();
      }
    }
}

function set(index,player){
  if(!game)
    return;

    if(state[index]==0){
      buttons[0].style.width = "0";
      buttons[0].style.margin = "0";
      buttons[0].style.opacity = "0";

      buttons[1].style.width = "32vh";


      if(player==HUMAN){
        tiles[index].style.background = "blue";
        state[index] = HUMVAL;
      }else{
        tiles[index].style.background = "red";
        state[index] = COMPUTER;
      }
    }

    if(cheackWIN(state,player)){
     if (player == HUMAN) {
      title.innerHTML = "Human Win";
     } else {
      title.innerHTML = "computer Win";
     }
      game=false;
    }
}

function cheackWIN(board,player){
  var value = player==HUMAN?HUMVAL:COMVAL;

  for (var i = 0; i < 8; i++) {
    var win = true;

    for (var j = 0; j < 3; j++) {
      if(board[winMatrix[i][j]]!=value){
        win=false;
        break;
      }
    }
    if(win)
      return true;
  }
  return false;
}

function cheackFull(board){
  for (var i = 0; i < 9; i++) {
    if(board[i]==0){
      return false;
    }
  }
  return true;
}

function callAI(){
  aiturn(state, 0, COMPUTER);
}

function aiturn(board,depth,player){
  if(cheackWIN(board,!player))
    return -10+depth;

    if(cheackFull(board))
      return 0;

      var value = player == HUMAN ? HUMVAL:COMVAL;

      var max = -Infinity;
      var index = 0;

      for (var i = 0; i < 9; i++) {
        if(board[i]==0){
          var newboard = board.slice();
          newboard[i]=value;

          var moveval = -aiturn(newboard,depth+1,!player);

          if(moveval>max){
            max = moveval;
            index = i;
          }
        }
      }
      if(depth==0)
        set(index,COMPUTER);

    return max;
}
