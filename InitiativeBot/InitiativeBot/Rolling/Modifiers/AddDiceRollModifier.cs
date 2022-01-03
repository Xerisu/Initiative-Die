﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitiativeBot.Rolling.Modifiers
{
    /// <summary>
    /// Adding another die to roll.
    /// </summary>
    public class AddDiceRollModifier : IRollModifier
    {
        private readonly IRoll _roll;
        private readonly IRoll _roll2;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="roll">Base roll.</param>
        /// <param name="roll2">Another roll.</param>
        public AddDiceRollModifier(IRoll roll, IRoll roll2)
        {
            _roll = roll;
            _roll2 = roll2;
        }

        /// <inheritdoc/> 
        public int RollDice()
        {
            return _roll.RollDice() + _roll2.RollDice();
        }

        public override string ToString()
        {
            string roll2Str = _roll2?.ToString() ?? "0";
            if (roll2Str[0] != '-')
                roll2Str = "+" + roll2Str;
            return _roll.ToString() + roll2Str;
        }
    }
}
