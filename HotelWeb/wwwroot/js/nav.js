const userButton = document.getElementById("userButton");
const userDropdown = document.getElementById("userDropdown");

userButton.addEventListener("click", () => {
    userDropdown.style.display = userDropdown.style.display === "flex" ? "none" : "flex";
});

// Cerrar si se hace clic fuera
document.addEventListener("click", function (event) {
    if (!userButton.contains(event.target) && !userDropdown.contains(event.target)) {
        userDropdown.style.display = "none";
    }
});