<template>
  <div class="container-fluid">
    <div class="row flex-nowrap">
      <div class="col-auto col-md-3 col-xl-2 px-sm-2 px-0 bg-primary">
        <div class="d-flex flex-column align-items-center align-items-sm-start px-3 pt-2 text-white min-vh-100">
          <a href="/" class="d-flex align-items-center pb-3 mb-md-0 me-md-auto text-white text-decoration-none">
            <span class="fs-5 d-none d-sm-inline">Menu</span>
          </a>
          <ul class="nav nav-pills flex-column mb-sm-auto mb-0 align-items-center align-items-sm-start" id="menu">
            <li class="nav-item">
              <router-link to="/home" class="nav-link align-middle px-0">
                <i class="fs-4 bi-house text-white"></i> <span class="ms-1 d-none d-sm-inline text-white">Home</span>
              </router-link>
            </li>
            <li>
              <router-link to="/registro" class="nav-link px-0 align-middle">
                <i class="fs-4 bi-card-checklist text-white"></i> <span class="ms-1 d-none d-sm-inline text-white">Registrar</span>
              </router-link>
            </li>
            <li>
              <router-link to="/edit" class="nav-link px-0 align-middle"> 
                <i class="fs-4 bi-pencil-square text-white"></i> <span class="ms-1 d-none d-sm-inline text-white">Modificar</span>
              </router-link>
            </li>
          </ul>
        </div>
      </div>
      <div class="col py-3">
        <router-view></router-view>
      </div>
    </div>
  </div>
</template>
