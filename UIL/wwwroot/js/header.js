const menu = document.querySelector('.header__menu');
const btn = document.querySelector('.header__profile');

btn.addEventListener('click', () => {
  menu.classList.toggle('active');
  console.log(menu);
});

const radios = document.querySelectorAll('[type=".item__controls > input"]');

document.addEventListener('click', (e) => {
	if (e.target.tagName.toLowerCase() !== 'input') {
		radios.forEach((radio) => {
			radio.checked = false;
		})
	}
});