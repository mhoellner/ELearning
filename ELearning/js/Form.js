window.onload = function () {
  var questionForm = document.getElementById('questionForm');

  questionForm.onsubmit = function () {

    var amountOfQuestionNotAnswered = 0;
    var fieldsets = questionForm.getElementsByTagName('fieldset');

    for (var fieldsetIndex = 0; fieldsetIndex < fieldsets.length; fieldsetIndex++) {

      var set = fieldsets[fieldsetIndex];
      var radios = set.getElementsByTagName('input');
      var checkedCounter = 0;

      for (var radioIndex = 0; radioIndex < radios.length; radioIndex++) {
        if (radios[radioIndex].checked) {
          checkedCounter++;
        }
      }
      if (checkedCounter === 0) {
        amountOfQuestionNotAnswered++;
      }
    }
    if (amountOfQuestionNotAnswered > 0) {
      var errorMessage = document.getElementById('formErrorMessage');
      errorMessage.className = 'alert alert-danger alert-dismissible';
      if (amountOfQuestionNotAnswered === 1) {
        errorMessage.innerHTML = 'Eine Frage wurde nicht beantwortet.';
      } else {
        errorMessage.innerHTML = 'Mehrere Fragen wurden nicht beantwortet.';
      }
      
      return false;
    } else {
      return true;
    }
  }
}