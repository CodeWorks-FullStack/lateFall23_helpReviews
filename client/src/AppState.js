import { reactive } from 'vue'
import { Restaurant } from './models/Restaurant.js'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  user: {},
  /** @type {import('./models/Account.js').Account} */
  account: {},
  /** @type {Restaurant[]} */
  restaurants: [],
  /** @type {Restaurant} */
  activeRestaurant: null,
  /** @type {Report[]} */
  reports: []
})
