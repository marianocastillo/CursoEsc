<!--<template>
  <div class="container">
    <div id="accordion">
      <div class="row">
        <div class="col-lg-12">
          <div class="text-center">
            <h3>High School Admission Recommendation Form</h3>
          </div>
        </div>
      </div>

      <div class="card card-default">
        <div class="card-header">
          <h4 class="card-title">
            <a data-toggle="collapse" data-parent="#accordion" href="#collapse1">
              <i class="glyphicon glyphicon-search text-gold"></i>
              <b>SECTION I: TO BE COMPLETED BY APPLICANT</b>
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
