<!--<template>
  <div class="container">
    <div id="accordion">
      <div class="row">
        <div class="col-lg-12">
          <div class="text-center">
            <h3>Formulario de Registro de Curso</h3>
          </div>
        </div>
      </div>

      <div class="card card-default">
        <div class="card-header">
          <h4 class="card-title">
            <a data-toggle="collapse" data-parent="#accordion" href="#collapse1">
              <i class="glyphicon glyphicon-search text-gold"></i>
              <b>Rellenar los Campo</b>
            </a>
          </h4>
        </div>
        <div id="collapse1" class="collapse show">
          <div class="card-body">
            <div class="row">
              <div class="col-md-3 col-lg-4">
                <div class="form-group">
                  <label class="control-label">Last Name</label>
                  <input type="text" class="form-control" />
                </div>
              </div>
              <div class="col-md-1 col-lg-4">
                <div class="form-group">
                  <label class="control-label">First Name</label>
                  <input type="text" class="form-control" />
                </div>
              </div>
              <div class="col-md-1 col-lg-1">
                <div class="form-group">
                  <label class="control-label">Middle.I</label>
                  <input class="form-control" type="text" />
                </div>
              </div>

              <div class="col-md-2 col-lg-3">
                <div class="form-group">
                  <label class="control-label">Date Of Birth</label>
                  <div class="input-group date">
                    <input class="form-control" type="text" ref="datepickerInput" />
                    <span class="input-group-append">
                      <button class="btn btn-outline-secondary" type="button">
                        <i class="fa fa-calendar"></i>
                      </button>
                    </span>
                  </div>
                </div>
              </div>
            </div>

            <div class="row">
              <div class="col-md-4 col-lg-4">
                <div class="form-group">
                  <label class="control-label">Mailing Address</label>
                  <input type="text" class="form-control" />
                </div>
              </div>
              <div class="col-md-2 col-lg-3">
                <div class="form-group">
                  <label class="control-label">City</label>
                  <input type="text" class="form-control" />
                </div>
              </div>

              <div class="col-md-3 col-lg-3">
                <div class="form-group">
                  <label class="control-label">State</label>
                  <input type="text" class="form-control" />
                </div>
              </div>

              <div class="col-md-3 col-lg-2">
                <div class="form-group">
                  <label class="control-label">Zip Code</label>
                  <input type="text" class="form-control" />
                </div>
              </div>
            </div>

            <div class="row">
              <div class="col-md-3 col-lg-12">
                <div class="form-group">
                  <label class="control-label">High School College/Name</label>
                  <input type="text" class="form-control" />
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>

</template>

<script setup>import { onMounted, ref } from 'vue';

  const datepickerInput = ref(null);

  onMounted(() => {
    if (window.$) {
      $(datepickerInput.value).datepicker({
        autoclose: true,
        todayHighlight: true
      });
    }
  });</script>-->

<!--<template>
  <div class="center"><button data-toggle="modal" data-target="#squarespaceModal" class="btn btn-primary center-block">Click Me</button></div>-->


  <!-- line modal -->
  <!--<div class="modal fade" id="squarespaceModal" tabindex="-1" role="dialog" aria-labelledby="modalLabel" aria-hidden="true">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">×</span><span class="sr-only">Close</span></button>
          <h3 class="modal-title" id="lineModalLabel">My Modal</h3>
        </div>
        <div class="modal-body">-->

          <!-- content goes here -->
          <!--<form>
            <div class="form-group">
              <label for="exampleInputEmail1">Email address</label>
              <input type="email" class="form-control" id="exampleInputEmail1" placeholder="Enter email">
            </div>
            <div class="form-group">
              <label for="exampleInputPassword1">Password</label>
              <input type="password" class="form-control" id="exampleInputPassword1" placeholder="Password">
            </div>
            <div class="form-group">
              <label for="exampleInputFile">File input</label>
              <input type="file" id="exampleInputFile">
              <p class="help-block">Example block-level help text here.</p>
            </div>
            <div class="checkbox">
              <label>
                <input type="checkbox"> Check me out
              </label>
            </div>
            <button type="submit" class="btn btn-default">Submit</button>
          </form>

        </div>
        <div class="modal-footer">
          <div class="btn-group btn-group-justified" role="group" aria-label="group button">
            <div class="btn-group" role="group">
              <button type="button" class="btn btn-default" data-dismiss="modal" role="button">Close</button>
            </div>
            <div class="btn-group btn-delete hidden" role="group">
              <button type="button" id="delImage" class="btn btn-default btn-hover-red" data-dismiss="modal" role="button">Delete</button>
            </div>
            <div class="btn-group" role="group">
              <button type="button" id="saveImage" class="btn btn-default btn-hover-green" data-action="save" role="button">Save</button>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>

</template>-->


<template>
  <div class="center"><button data-toggle="modal" data-target="#squarespaceModal" class="btn btn-primary center-block">Click Me</button></div>


  <!-- line modal -->
  <div class="modal fade" id="squarespaceModal" tabindex="-1" role="dialog" aria-labelledby="modalLabel" aria-hidden="true">
    <div class="modal-dialog">
      <div class="modal-content">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">×</span><span class="sr-only">Close</span></button>
          <h3 class="modal-title" id="lineModalLabel">My Modal</h3>
        </div>
        <div class="modal-body">

          <!-- content goes here -->
          <form>
            <div class="form-group">
              <label for="exampleInputEmail1">Email address</label>
              <input type="email" class="form-control" id="exampleInputEmail1" placeholder="Enter email">
            </div>
            <div class="form-group">
              <label for="exampleInputPassword1">Password</label>
              <input type="password" class="form-control" id="exampleInputPassword1" placeholder="Password">
            </div>
            <div class="form-group">
              <label for="exampleInputFile">File input</label>
              <input type="file" id="exampleInputFile">
              <p class="help-block">Example block-level help text here.</p>
            </div>
            <div class="checkbox">
              <label>
                <input type="checkbox"> Check me out
              </label>
            </div>
            <button type="submit" class="btn btn-default">Submit</button>
          </form>

        </div>
        <div class="modal-footer">
          <div class="btn-group btn-group-justified" role="group" aria-label="group button">
            <div class="btn-group" role="group">
              <button type="button" class="btn btn-default" data-dismiss="modal" role="button">Close</button>
            </div>
            <div class="btn-group btn-delete hidden" role="group">
              <button type="button" id="delImage" class="btn btn-default btn-hover-red" data-dismiss="modal" role="button">Delete</button>
            </div>
            <div class="btn-group" role="group">
              <button type="button" id="saveImage" class="btn btn-default btn-hover-green" data-action="save" role="button">Save</button>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>


</template>
