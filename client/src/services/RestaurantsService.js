import { AppState } from "../AppState.js"
import { Restaurant } from "../models/Restaurant.js"
import { logger } from "../utils/Logger.js"
import { api } from "./AxiosService.js"



class RestaurantsService{
async getRestaurants(){
  const response = await api.get('api/restaurants')
  logger.log('🍝', response.data)
  AppState.restaurants = response.data.map(restaurant => new Restaurant(restaurant));
}

async getRestaurantById(restaurantId){
  AppState.activeRestaurant = null
  const path = {one: 'api', two: 'restaurants', three: `${restaurantId}`} //🏴‍☠️💥
  const response = await api.get(Object.values(path).join('/'))
  logger.log('🍝', response.data)
  AppState.activeRestaurant = new Restaurant(response.data)
}
}

export const restaurantsService = new RestaurantsService()
