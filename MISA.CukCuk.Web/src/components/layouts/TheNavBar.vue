<template>
  <!-- menu trái -->
  <div class="navbar">
    <ul class="navbar__list">
     
      <!-- danh mục -->

      <router-link
        to="/dictionary/employee"
        id="dictionary-employee"
        class="navbar_item"
      >
        <li id="navbar__dictionary" class="navbar__item">
          <a href="#" class="navbar__link">
            <span
              class="navbar__item-icon navbar__item-icon--dictionary"
            ></span>
            <span class="navbar__item-text">Danh mục</span>
          </a>
        </li>
      </router-link>
    </ul>
  </div>
</template>

<script>
document.addEventListener("DOMContentLoaded", function() {
  var dictionary = document.getElementById("navbar__dictionary");
  var employee = document.getElementById("dictionary-employee");
  if (dictionary) {
    dictionary.addEventListener("click", function(e) {
      e.preventDefault();
      this.classList.add("active", "show-panel");
    });
  }
  if (employee) {
    employee.addEventListener("click", function(e) {
      e.stopPropagation();
      dictionary.classList.remove("show-panel");
    });
  }
});

export default {};
</script>

<style></style>
