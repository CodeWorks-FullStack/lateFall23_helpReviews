import { createRouter, createWebHashHistory } from 'vue-router'
import { authGuard, authSettled } from '@bcwdev/auth0provider-client'

function loadPage(page) {
  return () => import(`./pages/${page}.vue`)
}

const routes = [
  {
    path: '/',
    name: 'Home',
    component: loadPage('HomePage'),
    beforeEnter: authSettled
  },
  {
    path: '/about',
    name: 'About',
    component: loadPage('AboutPage')
  },
  {
    path: '/restaurant/:restaurantId',
    name: 'Restaurant Details Page',
    component: loadPage("RestaurantDetailsPage"),
    beforeEnter: authSettled //REVIEW Checks if it needs to WAIT for the user to log in first, or if they aren't authorized, it doesn't wait and just pushed them to the page
  },
  {
    path: '/account',
    name: 'Account',
    component: loadPage('AccountPage'),
    beforeEnter: authGuard // does not allow anyone who is NOT authorized through, redirects to a log in page
  }
]

export const router = createRouter({
  linkActiveClass: 'router-link-active',
  linkExactActiveClass: 'router-link-exact-active',
  history: createWebHashHistory(),
  routes
})
