import { defineNuxtConfig } from 'nuxt3'
import dotenv from 'dotenv';
dotenv.config();
export default defineNuxtConfig({
    target: 'server',
		srcDir: './',
		build: {
      postcss: {
        postcssOptions: {
          plugins: {
            tailwindcss: {},
            autoprefixer: {},
          }
        }
      },
    },
    head: {
        script: [
            {
                src: "https://kit.fontawesome.com/0cda3bb6df.js"
            }
        ],
        link: [
            { rel: "stylesheet", href: "https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css" },
            { rel: "icon", type: "image/x-icon", href: "/appexico.ico" }
        ]
    },
    /*axios: {
      baseURL: "http://localhost:3001"
    },*/
    publicRuntimeConfig: {
      // baseURL: process.env.BASE_URL
      baseURL: "https://localhost:7021"
    },
    privateRuntimeConfig: {
      // baseURL: process.env.BASE_URL
      baseURL: "https://localhost:7021"
    },
    buildModules: [
      // Nuxt 2 only:
      // https://composition-api.nuxtjs.org/getting-started/setup#quick-start
      '@pinia/nuxt',
    ],  
})
