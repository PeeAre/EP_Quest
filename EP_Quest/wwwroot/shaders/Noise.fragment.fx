precision highp float;

uniform sampler2D textureSampler;
uniform float time;
varying vec2 vUV;

// Функция для генерации псевдослучайного числа
float random(vec2 co) {
    return fract(sin(dot(co.xy, vec2(12.9898, 78.233))) * 43758.5453);
}

void main(void) {
    vec2 uv = vUV;

    // Генерируем случайное значение на основе координаты текстуры и времени
    float random_value = random(uv + floor(time));

    // Порог для определения, где применять помехи
    float threshold = 0.05;

    if (random_value < threshold) {
        // Используем цвета соседних пикселей для создания фрагментированных помех
        vec4 color = vec4(
            texture2D(textureSampler, uv).r,
            texture2D(textureSampler, uv).g,
            texture2D(textureSampler, uv).b,
            1.0
        );
        gl_FragColor = color;
    }
    else {
        // Если случайное значение не меньше порога, применяем ваш код
        float random_value = random(vec2(floor(uv.y * 8.0), time * 0.1));

        if (random_value < 0.02) {
            gl_FragColor = texture2D(textureSampler, vec2(uv.x + random_value * 0.8, uv.y - random_value * 0.2));
        } else {
            gl_FragColor = texture2D(textureSampler, uv);
        }
    }
}