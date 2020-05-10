import { environment } from 'src/environments/environment';

export  const apiUrls = {
    getWord: environment.apiUrl + environment.gameUrls.getWord,
     gameStatus: environment.apiUrl + environment.gameUrls.gameStatus,
     getScores: environment.apiUrl + environment.gameUrls.getScores,
     changeScores: environment.apiUrl + environment.gameUrls.changeScores,
     getLifes: environment.apiUrl + environment.gameUrls.getLifes,
     changeLifes: environment.apiUrl + environment.gameUrls.changeLifes,
     getJokers: environment.apiUrl + environment.gameUrls.getJockers,
     changeJokers: environment.apiUrl + environment.gameUrls.changeJockers,
     getNextWord: environment.apiUrl + environment.gameUrls.getNextWord,
     newGame: environment.apiUrl + environment.gameUrls.newGame,
     getVictimPicture: environment.apiUrl + environment.imageUrls.getVictimPicture,
     getNextVictimPicture: environment.apiUrl + environment.imageUrls.getNextVictimPicture,
     getLosePicture: environment.apiUrl + environment.imageUrls.getLosePictureUrl,
     getWinPicture:  environment.apiUrl + environment.imageUrls.getWinPictureUrl,

};