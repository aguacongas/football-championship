using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Aguacongas.FootballChampionship.Model
{
    public static class Mutations
    {
        public const string CREATE_BET = @"mutation CreateBet($input: CreateBetInput!) {
  createBet(input: $input) {
    id
    userName
    match {
      id
    }
    scores {
      isHome
      value
    }
  }
}";

        public const string UPDATE_BET = @"mutation UpdateBet($input: UpdateBetInput!) {
  updateBet(input: $input) {
    id
    userName
    match {
      id
    }
    scores {
      isHome
      value
    }
  }
}";
    }
}
