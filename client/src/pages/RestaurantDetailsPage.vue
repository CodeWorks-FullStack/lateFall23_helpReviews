<template>
  <div class="container-fluid">

    THIS IS THE RESTAURANT DETAILS PAGE
    <!-- {{ restaurant }}
     -->
     <section class="row" v-if="restaurant">
      <div class="col-12">
        <div class="d-flex justify-content-between align-items-baseline">
          <span class="display-4 text-success">{{ restaurant.name }}</span>
          <span v-if="restaurant.shutdown" class="bg-danger text-light p-2 fw-bold"><i class="mdi mdi-close-circle"></i>Current Shutdown</span>
        </div>
        <img class="cover-img  mb-2" :src="restaurant.coverImg" alt="">
        <div class="d-flex justify-content-between">
          <div>
              <span class="fw-bold">{{ restaurant.owner.name }}</span>
            <img class="profile-img" :src="restaurant.owner.picture" alt="">
          </div>
        </div>
        <p>{{ restaurant.description }}</p>
        <div>
          <i class="mdi mdi-account-group"></i><span>{{ restaurant.visitCount }}</span>
          <i class="mdi mdi-file"></i><span>{{ restaurant.reportCount }}</span>
        </div>
      </div>
     </section>
  </div>
</template>


<script>
import { useRoute, useRouter } from 'vue-router';
import { AppState } from '../AppState';
import { computed, ref, onMounted } from 'vue';
import Pop from '../utils/Pop.js';
import { restaurantsService } from '../services/RestaurantsService.js';
export default {
  setup(){
    onMounted(()=>{
      getRestaurantById()
    })
    const route = useRoute()
    const router = useRouter()
    async function getRestaurantById(){
      try {
        await restaurantsService.getRestaurantById(route.params.restaurantId)
      } catch (error) {
        Pop.error(error, '[GET RESTAURANT BY ID]')
        router.push({name: 'Home'})
      }
    }
  return {
    restaurant: computed(()=> AppState.activeRestaurant)
   }
  }
};
</script>


<style lang="scss" scoped>
.cover-img{
  height: 30dvh;
  width: 100%;
  object-fit: cover;
  object-position: center;
}
.profile-img{
  height: 50px;
  width: 50px;
  object-fit: cover;
  border-radius: 50em;
}
</style>
