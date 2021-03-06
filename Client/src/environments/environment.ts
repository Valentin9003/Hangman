// This file can be replaced during build by using the `fileReplacements` array.
// `ng build --prod` replaces `environment.ts` with `environment.prod.ts`.
// The list of file replacements can be found in `angular.json`.

export const environment = {
  production: false,
  apiUrl: "https://localhost:44332/",
  gameUrls:{
    getWord: "game/getword",
    gameStatus: "game/gamestatus",
    getLifes: "game/getlifes",
    changeLifes: "game/changelifes", 
    getJockers: "game/getjokers",
    changeJockers: "game/changejokers",
    getScores: "game/getscores",
    changeScores: "game/changescores",
    getNextWord: "game/getnextword",
    newGame: "game/newgame"
  },
  authUrls:{
   register: "identity/register",
   login: "identity/login",
   getUsername: "identity/getusername"
  },
  userInfoUrls:{
    changePassword: "identity/changepassword",
    changeEmail: "identity/changeemail",
    getPassword: "identity/getPassword",
    getEmail: "identity/getemail"
  },
  imageUrls:{
    getVictimPicture: "victimpicture/getvictimpicture",
    getNextVictimPicture: "victimpicture/getnextvictimvicture",
    getLosePictureUrl: "victimpicture/getlosepicture",
    getWinPictureUrl: "victimpicture/getwinpicture"
  }
};

/*
 * For easier debugging in development mode, you can import the following file
 * to ignore zone related error stack frames such as `zone.run`, `zoneDelegate.invokeTask`.
 *
 * This import should be commented out in production mode because it will have a negative impact
 * on performance if an error is thrown.
 */
// import 'zone.js/dist/zone-error';  // Included with Angular CLI.
