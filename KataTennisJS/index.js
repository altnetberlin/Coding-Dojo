module.exports.Game = function(){
	var log = [],
		self = this,
		scoreCard = { 0: "0", 1: "15", 2:"30", 3:"40", 4:"adv", 5:"win"};
	
	self.scoreA = function(acc){
		self.score(acc, "playerA", "playerB");
	};
	self.scoreB = function(acc){
		self.score(acc, "playerB", "playerA");

	};
	self.score = function(currentGameState, scoring, other){
		if(currentGameState[scoring] === 3 && currentGameState[other]< 3) currentGameState[scoring] = 5;
		else if(currentGameState[other] === 4 && currentGameState[scoring] === 3) currentGameState[other] = 3;
		else currentGameState[scoring] += 1;
	};
	return {
		scoreA: function(){
			log.push({type:"scoreA"});
		},
		scoreB: function(){
			log.push({type:"scoreB"});
		},
		evaluate: function(){
			return log.reduce(function(acc, n){
				if(acc.playerA === 5 || acc.playerB === 5) return acc;
				self[n.type](acc);
				acc.results = scoreCard[acc.playerA]+"-"+scoreCard[acc.playerB];
				return acc;
			}, {playerA:0, playerB:0, results: "0-0"});
		}
	}
}