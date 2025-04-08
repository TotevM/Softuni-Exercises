document.addEventListener('DOMContentLoaded', solve);

function solve() {
    const quizSectionsElements = document.querySelectorAll('section');
    const resultsSectionElement = document.getElementById('results');
    const correctAnswers = [
        'onclick',
        'JSON.stringify()',
        'A programming API for HTML and XML documents',
    ];
    let rightAnswers = 0;

    quizSectionsElements.forEach((section, index) => {
        const answers = section.querySelectorAll('.quiz-answer');
        answers.forEach((answer) => {
            answer.addEventListener('click', () => {
                const answerText = answer.textContent.trim();

                if (answerText === correctAnswers[index]) {
                    rightAnswers++;
                }

                section.classList.add('hidden');

                if (index < quizSectionsElements.length - 1) {
                    quizSectionsElements[index + 1].classList.remove('hidden');
                } else {
                    resultsSectionElement.style.display = 'block';
                    resultsSectionElement.innerHTML = `<h1>${
                        rightAnswers === correctAnswers.length
                            ? 'You are recognized as top JavaScript fan!'
                            : `You have ${rightAnswers} right answer${
                                  rightAnswers !== 1 ? 's' : ''
                              }`
                    }</h1>`;
                }
            });
        });
    });
}
