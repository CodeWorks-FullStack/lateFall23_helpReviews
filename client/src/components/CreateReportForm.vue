<template>
  <form  class="row" @submit.prevent="createReport()">
    <div class="mb-3 col-6">
      <img v-if="selectedRestaurant" :src="selectedRestaurant.coverImg" class="img-fluid" alt="preview of restaurant selected">
    </div>
    <div class="mb-3 col-6">
      <label for="restaurant-select">Pick a Restaurant to Report</label>
      <select v-model="reportData.restaurantId" class="form-control" name="restaurant-select" required id="restaurant-select">
        <option v-for="restaurant in restaurants" :key="restaurant.id" :value="restaurant.id">{{ restaurant.name }}</option>
      </select>
    </div>
    <div class="mb-3 col-12">
      <label for="create-report-title">Title</label>
      <input v-model="reportData.title" type="text" class="form-control" minlength="3" maxlength="50" required>
    </div>
    <div class="mb-3 col-12">
      <label for="create-report-body">Body</label>
      <textarea v-model="reportData.body" required minlength="10" maxlength="500" name="create-report-body" id="create-report-body" class="form-control" rows="3"></textarea>
    </div>
    <div class="mb-3 col-12 text-end">
      <button class="btn btn-success rounded-0" type="submit">Create <i class="mdi mdi-plus"></i></button>
    </div>
  </form>
</template>


<script>
import { AppState } from '../AppState.js';
import { computed, ref } from 'vue';
import Pop from '../utils/Pop.js';
import { reportsService } from '../services/ReportsService.js';
import { Modal } from 'bootstrap';
export default {
setup(){
  const reportData = ref({})
return{
  reportData,
  restaurants: computed(()=> AppState.restaurants),
  selectedRestaurant: computed(()=> AppState.restaurants.find(restaurant => restaurant.id == reportData.value.restaurantId)),
  async createReport(){
    try {
      await reportsService.createReport(reportData.value)
      Modal.getOrCreateInstance("#create-report").hide()
      reportData.value = {}
      Pop.success("Report Filed")
    } catch (error) {
      Pop.error(error)
    }
  }
}
}
}
</script>


<style lang="scss" scoped>

</style>
