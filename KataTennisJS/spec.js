var assert = require("assert"),
	tennis = require("./index.js"),
	game;

describe('Play Tennis', function(){
	describe('add score by players', function(){
		beforeEach(function(){
			game = new tennis.Game();
		});
		it('should results 0-0', function(){
			var actual = game.evaluate();
			assert.equal(actual.results,"0-0");
		}),
		it('should results 15-0', function(){
			game.scoreA();
			var actual = game.evaluate();
			assert.equal(actual.results,"15-0");
		}),
		it('should results 30-0', function(){
			game.scoreA();
			game.scoreA();
			var actual = game.evaluate();
			assert.equal(actual.results,"30-0");
		}),
		it('should results 40-0', function(){
			game.scoreA();
			game.scoreA();
			game.scoreA();
			var actual = game.evaluate();
			assert.equal(actual.results,"40-0");
		}),
		it('should results 40-40', function(){
			game.scoreA();
			game.scoreA();
			game.scoreA();
			game.scoreB();
			game.scoreB();
			game.scoreB();
			var actual = game.evaluate();
			assert.equal(actual.results,"40-40");
		}),
		it('should results win-0', function(){
			game.scoreA();
			game.scoreA();
			game.scoreA();
			game.scoreA();
			var actual = game.evaluate();
			assert.equal(actual.results,"win-0");
		}),
		it('deuce adv should results adv-40', function(){
			game.scoreA();
			game.scoreA();
			game.scoreA();
			game.scoreB();
			game.scoreB();
			game.scoreB();

			game.scoreA();
			var actual = game.evaluate();
			assert.equal(actual.results,"adv-40");
		}),
		it('deuce adv should results win-40', function(){
			game.scoreA();
			game.scoreA();
			game.scoreA();
			game.scoreB();
			game.scoreB();
			game.scoreB();

			game.scoreA();
			game.scoreA();

			var actual = game.evaluate();
			assert.equal(actual.results,"win-40");
		}),
		it('deuce adv should results win-40 (edge)', function(){
			game.scoreA();
			game.scoreA();
			game.scoreA();
			game.scoreB();
			game.scoreB();
			game.scoreB();

			game.scoreA();
			game.scoreA();
			game.scoreA();
			game.scoreA();
			game.scoreA();
			game.scoreA();
			game.scoreA();

			var actual = game.evaluate();
			assert.equal(actual.results,"win-40");
		}),

		it('deuce adv should results 40-40', function(){
			game.scoreA();
			game.scoreA();
			game.scoreA();
			game.scoreB();
			game.scoreB();
			game.scoreB();

			game.scoreA();
			game.scoreB();

			var actual = game.evaluate();
			assert.equal(actual.results,"40-40");
		});
	});
});