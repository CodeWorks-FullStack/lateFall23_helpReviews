<template>
  <div class="container-fluid">
    <section class="row g-1">

        <!-- {{ restaurants }} -->
        <div v-for="restaurant in restaurants" :key="restaurant.id" class="col-md-4">
          <!-- {{ restaurant.name }} -->
          <RestaurantCard :restaurant="restaurant"/>
        </div>

    </section>
  </div>
</template>

<script>
import { computed, onMounted } from 'vue';
import { AppState } from '../AppState.js';
import Pop from '../utils/Pop.js';
import { restaurantsService } from '../services/RestaurantsService.js';
import RestaurantCard from '../components/RestaurantCard.vue'

export default {
  setup() {
    onMounted(()=>{
      getRestaurants()
    })

    async function getRestaurants(){
      try {
        await restaurantsService.getRestaurants()
      } catch (error) {
        Pop.error(error, '[GET RESTAURANTS]')
      }
    }
    return {
    restaurants: computed(()=> AppState.restaurants)
    }
  },
  components: { RestaurantCard}
}
</script>

<style scoped lang="scss">
.home {
  display: grid;
  height: 80vh;
  place-content: center;
  text-align: center;
  user-select: none;

  .home-card {
    width: clamp(500px, 50vw, 100%);

    >img {
      height: 200px;
      max-width: 200px;
      width: 100%;
      object-fit: contain;
      object-position: center;
    }
  }
}
</style>
