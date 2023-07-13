#Stage 1: Compile and build angular codebase

FROM node:latest as build

WORKDIR /app

COPY ./ /app

RUN npm install

RUN npm run build

#Stage 2: Serve app
FROM nginx:latest

COPY --from=build /app/dist/library-app /sur/share/nginx/html

EXPOSE 80
