    let currentIndex = 0;
    const mainImage = document.getElementById("mainImage");
    const thumbnails = document.querySelectorAll(".thumb");
    const progressSegments = Array.from(document.querySelectorAll(".progress-segment"));

  // Obtenemos las rutas de las miniaturas directamente
  const images = Array.from(thumbnails).map(thumb => thumb.getAttribute("src"));

    function showImage(index) {
        mainImage.classList.remove("fade-in");
    void mainImage.offsetWidth; // fuerza el reflow para reiniciar la animación
    mainImage.src = images[index];
    mainImage.classList.add("fade-in");

    // Actualizar thumbnails activos
    thumbnails.forEach(t => t.classList.remove("active"));
    thumbnails[index].classList.add("active");

    // Actualizar progreso
    progressSegments.forEach(seg => seg.classList.remove("active"));
    progressSegments[index]?.classList.add("active");
  }

    // Inicializar
    showImage(currentIndex);

  let interval = setInterval(() => {
        currentIndex = (currentIndex + 1) % images.length;
    showImage(currentIndex);
  }, 10000);

  // Clic en miniaturas
  thumbnails.forEach((thumb, index) => {
        thumb.addEventListener("click", () => {
            currentIndex = index;
            showImage(index);

            clearInterval(interval);
            interval = setInterval(() => {
                currentIndex = (currentIndex + 1) % images.length;
                showImage(currentIndex);
            }, 10000);
        });
  });
