import Vue from 'vue'
import Router from 'vue-router'
// @ts-ignore
import Home from './views/Home.vue'
// @ts-ignore
import Login from './views/Login.vue'
// @ts-ignore
import UserVaults from './components/UserVaults.vue'
// @ts-ignore
import Vault from './components/Vault.vue'
// @ts-ignore
import Keeps from './components/Keeps.vue'

Vue.use(Router)

export default new Router({
  routes: [
    {
      path: '/',
      name: 'home',
      component: Home
    },
    {
      path: '/login',
      name: 'login',
      component: Login
    },
    {
      path: '/uservaults',
      name: 'uservaults',
      component: UserVaults
    },
    {
      path: '/vaults/:vaultId',
      name: 'vault',
      props: true,
      component: Vault
    },
    {
      path: '/keeps',
      name: 'keeps',
      component: Keeps
    },
    {
      path: '*',
      redirect: '/'
    },

  ]
})
