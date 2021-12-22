$(document).ready(function () {
    JuniorMath.ExamPaper.Init();
});

JuniorMath.ExamPaper = {

    Init: function () {

        var main = $('main.main');
        var viewExamPaperContent = main.find('div.view-exam-paper-content');
        var imageAreas = viewExamPaperContent.find('div.image-area');

        $(imageAreas).each(function () {
            var imageArea = $(this);

            imageArea.click(function () {
                JuniorMath.ExamPaper.SetImageAreaAction(imageArea);
            });
        });
    },

    SetImageAreaAction: function (imageArea) {
        var hiddenInput = imageArea.find('input.hidden-input');
        var questionImage = imageArea.find('img.question-image');
        var greenCkeckImage = imageArea.find('img.green-check');
        if (hiddenInput.val() === "0") {
            hiddenInput.val("1");
            greenCkeckImage.show();
            questionImage.hide();
        }
        else {
            hiddenInput.val("0");
            greenCkeckImage.hide();
            questionImage.show();
        }
    },

    SubmitExamModal: function () {

        var examAnswer = {
            exam_id: 0,
            questions: []
        };

        var main = $('main.main');
        var viewExamPaperContent = main.find('div.view-exam-paper-content');
        var inputExamId = viewExamPaperContent.find('input.hidden-exam-id');
        examAnswer.exam_id =parseInt( inputExamId.val());

        // Question Block
        var divQuestionBlocks = viewExamPaperContent.find('div.question-block');
        divQuestionBlocks.each(function () {
            var divQuestionBlock = $(this);
            var question = {
                question_id: 0,
                question_details: []
            }
            var inputQuestionId = divQuestionBlock.find('input.hidden-question-id');
            question.question_id = parseInt(inputQuestionId.val());

            examAnswer.questions.push(question);

            // Question Detail Block
            var divQuestionDetailBlocks = divQuestionBlock.find('div.question-detail');

            divQuestionDetailBlocks.each(function () {
                var divQuestionDetailBlock = $(this);
                var inputQuestionDetailId = divQuestionDetailBlock.find('input.hidden-question-detail-id');
                var inputQuestionDetailAnswer = divQuestionDetailBlock.find('input.input-question-answer');

                var questionDetailAnswer = {
                    question_detail_id: parseInt(inputQuestionDetailId.val()),
                    question_detail_answer: inputQuestionDetailAnswer.val()
                };

                question.question_details.push(questionDetailAnswer);
            });

        });

        var jsonData = JSON.stringify(examAnswer);
        var dataType = 'application/json; charset=utf-8';

        $.ajax({
            type: "POST",
            url: "/api/Exam",
            contentType: dataType,
            dataType: "json",
            data: jsonData,
            success: function (result) {

                alert("success");
                //window.location.replace('/Invoice/InvoiceDetail?invoiceId=' + result.displayId);

            }, //End of AJAX Success function  

            failure: function (data) {
                alert(data.responseText);
            }, //End of AJAX failure function  
            error: function (data) {
                alert(data.responseText);
            } //End of AJAX error function  
        });
    }
};






