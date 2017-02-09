window.onload = function () {
  var questionForm = document.getElementById('questionForm');
  questionForm.onsubmit = function () {
    var anyQuestionNotAnswered = true;
    if (anyQuestionNotAnswered) {
      var errorMessage = document.getElementById('formErrorMessage');
      errorMessage.innerHTML = 'Eine oder mehrere Fragen wurden nicht beantwortet';
      return false;
    } else {
      return true;
    }
  }
}