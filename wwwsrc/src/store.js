import Vue from 'vue'
import Vuex from 'vuex'
import Axios from 'axios'
import router from './router'

Vue.use(Vuex)

let auth = Axios.create({
  baseURL: "http://localhost:5000/account/",
  timeout: 3000,
  withCredentials: true
})

let api = Axios.create({
  baseURL: "http://localhost:5000/api/",
  timeout: 3000,
  withCredentials: true
})

export default new Vuex.Store({
  state: {
    user: {},
    keeps: {},
    vaults: [],

    vaultkeeps: {}
  },
  mutations: {
    setKeeps(state, keeps) {
      state.keeps = keeps
    },
    setVaults(state, vaults) {
      state.vaults = vaults
    },
    setVaultKeeps(state, vaultkeeps) {
      state.vaults = vaultkeeps
    },
    setUser(state, user) {
      state.user = user
    }
  },
  actions: {
    register({ commit, dispatch }, newUser) {
      auth.post('register', newUser)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('[registration failed] :', e)
        })
    },
    authenticate({ commit, dispatch }) {
      auth.get('authenticate')
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('not authenticated')
        })
    },
    login({ commit, dispatch }, creds) {
      auth.post('login', creds)
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'home' })
        })
        .catch(e => {
          console.log('Login Failed')
        })
    },
    logout({ commit, dispatch }, creds) {
      auth.delete('logout')
        .then(res => {
          commit('setUser', res.data)
          router.push({ name: 'login' })
        })
    },
    newKeep({ commit, dispatch }, creds) {
      auth.post('', creds)
        .then(res => {
          commit('')
        })
        .catch(error => {
          console.log("Unable to create keep")
        })
    },
    newVault({ commit, dispatch }, creds) {
      auth.post('', creds)
        .then(res => {
          commit('')
        })
        .catch(error => {
          console.log("Unable to create vault")
        })
    },
    // getAllVaults({ commit, dispatch }) {
    //   debugger
    //   api.get('keeps')
    //     .then(res => {
    //       commit('setKeeps', res.data)
    //     })
    //   }, NEED THIS BY USERID
    getAllKeeps({ commit, dispatch }) {
      api.get('keeps')
        .then(res => {
          commit('setKeeps', res.data)
        })
    }
  }
})

