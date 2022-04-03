const hero_slide_items = document.querySelectorAll('.slide');
let hero_slide_index = 0;
let hero_slide_play = true;
const hero_slide_items_control = document.querySelectorAll('.slide__control__item');

console.log(hero_slide_items);

const slide_next = document.querySelector('.slide__control_next');

const slide_prev = document.querySelector('.slide__control_prev');

const showSlide = (index) => {
  document.querySelector('.slide.active').classList.remove('active');
  document.querySelector('.slide__control__item.active').classList.remove('active');
  hero_slide_items[index].classList.add('active');
  hero_slide_items_control[index].classList.add('active');
};

const nextSlide = () => {
  hero_slide_index = hero_slide_index + 1 === hero_slide_items.length ? 0 : hero_slide_index + 1;

  showSlide(hero_slide_index);
};

const prevSlide = () => {
  hero_slide_index = hero_slide_index - 1 < 0 ? hero_slide_items.length - 1 : hero_slide_index - 1;

  showSlide(hero_slide_index);
};

if (slide_next && slide_prev) {
  slide_next.addEventListener('click', () => nextSlide());
  slide_prev.addEventListener('click', () => prevSlide());
  hero_slide_items_control.forEach((item, index) => {
    item.addEventListener('click', () => showSlide(index));
  });

  setInterval(() => {
    nextSlide();
  }, 3000);
}

const showMenu = (toggleId, navbarId, bodyId) => {
  const toggle = document.getElementById(toggleId),
    navbar = document.getElementById(navbarId),
    bodypadding = document.getElementById(bodyId);

  if (toggle && navbar) {
    toggle.addEventListener('click', () => {
      navbar.classList.toggle('expander');

      bodypadding.classList.toggle('body-pd');
    });
  }
};
showMenu('nav-toggle', 'navbar', 'body-pd');

/*===== LINK ACTIVE  =====*/
const linkColor = document.querySelectorAll('.nav__link');
function colorLink() {
  linkColor.forEach((l) => l.classList.remove('active'));
  this.classList.add('active');
}
linkColor.forEach((l) => l.addEventListener('click', colorLink));

/*===== COLLAPSE MENU  =====*/
const linkCollapse = document.getElementsByClassName('collapse__link');
var i;

for (i = 0; i < linkCollapse.length; i++) {
  linkCollapse[i].addEventListener('click', function () {
    const collapseMenu = this.nextElementSibling;
    collapseMenu.classList.toggle('showCollapse');

    const rotate = collapseMenu.previousElementSibling;
    rotate.classList.toggle('rotate');
  });
}



const activeModel = document.querySelector(".active-videodemo");
const videoDemo = document.querySelector(".model");
const overley = document.querySelector(".model .overlay")

const video = document.getElementById("model-cate");

if (activeModel) {
    activeModel.addEventListener("click", () => {
        videoDemo.classList.add("active");
    })

    overley.addEventListener("click", () => {
        videoDemo.classList.remove("active");
    })  
}

const listMatch = document.querySelectorAll(".match__right ul li");
const frameMatch = document.querySelector(".match__left__frame iframe")

if (listMatch) {
    listMatch.forEach((item) => {
        item.addEventListener("click", () => {
            const url = item.getAttribute("data-title");
            const urlAutoPlay = url + "?autoplay=1";
            const ActiveLi = document.querySelector(".match__right ul li.active")
            if (ActiveLi) {
                ActiveLi.classList.remove('active');
                
            }
            item.classList.add('active');
            const titleTemp = item.querySelector("a div h5");
            const title = document.querySelector(".match__left__heading");
            console.log(" ", titleTemp, { title });
            title.innerText = titleTemp.innerText;
            frameMatch.setAttribute('src', urlAutoPlay);
        })
    })
}